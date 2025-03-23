using OeX.Management.Domain.MotivosParada;
using OeX.Management.Domain.MotivosParada.Interfaces;
using OeX.Management.Infrastructure.Context;

namespace OeX.Management.Infrastructure.Repository.MotivosParada
{
    public class MotivoParadaRepository : IMotivoParadaRepository
    {
        private readonly RNContext _rnContext;

        public MotivoParadaRepository(RNContext rnContext)
        {
            _rnContext = rnContext;
        }

        public void Adicionar(MotivoParada entity)
        {
           _rnContext.MotivosParada.Add(entity);
           _rnContext.SaveChanges();
        }

        public void Atualizar(MotivoParada entity)
        {
            _rnContext.MotivosParada.Update(entity);
            _rnContext.SaveChanges();
        }

        public void Remover(MotivoParada entity)
        {
            _rnContext.MotivosParada.Remove(entity); //se tiver só o id preenchido remove igual
            _rnContext.SaveChanges();
        }
    }
}
