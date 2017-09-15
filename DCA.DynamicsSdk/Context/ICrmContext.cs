using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;

namespace DCA.DynamicsSdk
{
    public interface ICrmContext
    {
        OrganizationServiceProxy ServiceProxy { get; }

        Guid Create(Entity entity);

        void Update(Entity entity);               

        void Delete(Guid id, string entityName);
    }
}