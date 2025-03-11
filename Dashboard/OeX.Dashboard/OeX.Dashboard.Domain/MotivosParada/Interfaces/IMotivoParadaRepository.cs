namespace OeX.Dashboard.Domain.MotivosParada.Interfaces
{
    public interface IMotivoParadaRepository
    {
        void Adicionar(MotivoParada entity);
        void Atualizar(MotivoParada entity);
        void Remover(MotivoParada entity);
        Task<MotivoParada?> BuscarPorIdManagementEEmpresa(
            long managementId,
            Guid empresaId);
    }
}
