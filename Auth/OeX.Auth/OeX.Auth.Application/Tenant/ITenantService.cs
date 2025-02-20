namespace OeX.Auth.Application.Tenants
{
    public interface ITenantService
    {
        string GetTenant();
        void SetTenant(string tenantId);
    }
}
