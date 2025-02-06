using OeX.Auth.Domain.Commons;

namespace OeX.Auth.Domain.Empresas.Interfaces
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa entity); 
        void Atualizar(Empresa entity);
        void Remover(Empresa entity);
    }
}
