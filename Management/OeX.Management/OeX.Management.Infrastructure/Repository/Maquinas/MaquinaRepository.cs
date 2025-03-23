using OeX.Management.Domain.Maquinas;
using OeX.Management.Domain.Maquinas.Interfaces;
using OeX.Management.Infrastructure.Context;

namespace OeX.Management.Infrastructure.Repository.Maquinas
{
    public class MaquinaRepository : IMaquinaRepository
    {
        private readonly RNContext _rnContext;
        public MaquinaRepository(RNContext rnContext)
        {
            _rnContext = rnContext;
        }

        public void Adicionar(Maquina entity)
        {
            _rnContext.Maquinas.Add(entity);
            _rnContext.SaveChanges();
        }

        public void Atualizar(Maquina entity)
        {
            _rnContext.Maquinas.Update(entity);
            _rnContext.SaveChanges();
        }

        public void Remover(Maquina entity)
        {
            _rnContext.Maquinas.Remove(entity); //se tiver só o id preenchido remove igual
            _rnContext.SaveChanges();
        }

    }

}
