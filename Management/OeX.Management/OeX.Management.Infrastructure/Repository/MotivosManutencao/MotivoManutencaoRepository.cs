using OeX.Management.Domain.MotivosManutencao;
using OeX.Management.Domain.MotivosManutencao.Interfaces;
using OeX.Management.Infrastructure.Context;

namespace OeX.Management.Infrastructure.Repository.MotivosManutencao
{
    public class MotivoManutencaoRepository : IMotivoManutencaoRepository
    {
        private readonly RNContext _rnContext;
        public MotivoManutencaoRepository(RNContext rnContext)
        {
            _rnContext = rnContext;
        }

        public void Adicionar(MotivoManutencao entity)
        {
            _rnContext.MotivosManutencao.Add(entity);
            _rnContext.SaveChanges();
        }

        public void Atualizar(MotivoManutencao entity)
        {
            _rnContext.MotivosManutencao.Update(entity);
            _rnContext.SaveChanges();
        }

        public void Remover(MotivoManutencao entity)
        {
            _rnContext.MotivosManutencao.Remove(entity); //se tiver só o id preenchido remove igual
            _rnContext.SaveChanges();
        }

    }
}
