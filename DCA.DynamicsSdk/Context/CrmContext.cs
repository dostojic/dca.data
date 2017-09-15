using DCA.Core.Data.Exceptions;
using DCA.DynamicsSdk.Factories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace DCA.DynamicsSdk
{
    public class CrmContext : ICrmContext
    {
        private readonly IOrganizationServiceProxyFactory _organizationServiceProxyFactory;

        public CrmContext(IOrganizationServiceProxyFactory organizationServiceProxyFactory)
        {
            _organizationServiceProxyFactory = organizationServiceProxyFactory;
        }

        public OrganizationServiceProxy ServiceProxy => _organizationServiceProxyFactory.GetOrganizationServiceProxy();

        public Guid Create(Entity entity)
        {
            return Execute(serviceProxy => serviceProxy.Create(entity));
        }

        public void Delete(Guid id, string entityName)
        {
            Execute<object>(serviceProxy =>
            {
                serviceProxy.Delete(entityName, id);
                return null;
            });
        }

        public void Update(Entity entity)
        {
            Execute<object>(serviceProxy =>
            {
                serviceProxy.Update(entity);
                return null;
            });
        }

        private TResult Execute<TResult>(Func<OrganizationServiceProxy, TResult> function)
        {
            try
            {
                using (var serviceProxy = ServiceProxy)
                {
                    return function(serviceProxy);
                }
            }
            catch (ExpiredSecurityTokenException ex)
            {
                //_logger.ErrorException("CRM Sercurity Token Expired", ex);

                throw;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                HandleKnownFaultExceptions(ex);
                //_logger.ErrorException("CRM Service Fault", ex);

                throw new DataFaultException(ex);
            }
            catch (SecurityAccessDeniedException ex)
            {
                //_logger.ErrorException("CRM Access Denied", ex);
                throw new AccessDeniedDataException(ex);
            }
        }

        private void HandleKnownFaultExceptions(FaultException<OrganizationServiceFault> ex)
        {
            if (ex.Detail.InnerFault != null && ex.Detail.InnerFault.ErrorCode == -2147220969)
            {
                throw new EntityNotFoundException(ex);
            }
        }
    }
}