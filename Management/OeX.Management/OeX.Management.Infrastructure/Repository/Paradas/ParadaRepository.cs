using OeX.Management.Domain.Paradas;
using OeX.Management.Domain.Paradas.Interfaces;
using OeX.Management.Infrastructure.Context;

namespace OeX.Management.Infrastructure.Repository.Paradas
{
    public class ParadaRepository : IParadaRepository
    {
        private readonly RNContext _rnContext;
        public ParadaRepository(RNContext rnContext)
        {
            _rnContext = rnContext;
        }

        public void Adicionar(Parada entity)
        {
            _rnContext.Paradas.Add(entity);
            _rnContext.SaveChanges();
        }

        public void Atualizar(Parada entity)
        {
            _rnContext.Paradas.Update(entity);
            _rnContext.SaveChanges();
        }

        public void Remover(Parada entity)
        {
            _rnContext.Paradas.Remove(entity); //se tiver só o id preenchido remove igual
            _rnContext.SaveChanges();
        }

    }
}

