using OeX.Auth.Domain.Tenants;

namespace OeX.Auth.Application.Tenants
{
    public class TenantService : ITenantService
    {
       private string _tenantId = string.Empty;

        public string GetTenant() => _tenantId;

        public void SetTenant(string tenantId) => _tenantId = tenantId;
    }
}
