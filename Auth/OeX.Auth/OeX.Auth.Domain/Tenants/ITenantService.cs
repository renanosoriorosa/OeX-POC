namespace OeX.Auth.Domain.Tenants
{
    public interface ITenantService
    {
        string GetTenant();
        void SetTenant(string tenantId);
    }
}
