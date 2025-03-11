using OeX.Management.Domain.MotivosParada;
using OeX.Management.Domain.MotivosParada.Interfaces;
using OeX.Management.Infrastructure.Context;

namespace OeX.Management.Infrastructure.Repository.MotivosParada
{
    public class MotivoParadaRepository : Repository<MotivoParada>, IMotivoParadaRepository
    {
        public MotivoParadaRepository(RNContext db) : base(db)
        {

        }
    }
}
