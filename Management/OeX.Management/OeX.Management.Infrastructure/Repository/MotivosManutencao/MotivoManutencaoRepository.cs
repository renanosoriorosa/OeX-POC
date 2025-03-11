using OeX.Management.Domain.MotivosManutencao;
using OeX.Management.Domain.MotivosManutencao.Interfaces;
using OeX.Management.Infrastructure.Context;

namespace OeX.Management.Infrastructure.Repository.MotivosManutencao
{
    public class MotivoManutencaoRepository : Repository<MotivoManutencao>, IMotivoManutencaoRepository
    {
        public MotivoManutencaoRepository(RNContext db) : base(db)
        {

        }
    }
}
