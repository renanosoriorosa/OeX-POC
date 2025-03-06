namespace OeX.Dashboard.Domain.Empresas.Interfaces
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa entity);
        void Atualizar(Empresa entity);
        void Remover(Empresa entity);
    }
}
