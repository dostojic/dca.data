using Microsoft.Xrm.Sdk.Client;

namespace DCA.DynamicsSdk.Factories
{
    public interface IOrganizationServiceProxyFactory
    {
        OrganizationServiceProxy GetOrganizationServiceProxy();
    }
}
