using OeX.Management.Domain.Maquinas;
using OeX.Management.Domain.Maquinas.Interfaces;
using OeX.Management.Infrastructure.Context;

namespace OeX.Management.Infrastructure.Repository.Maquinas
{
    public class MotivoManutencaoRepository : Repository<Maquina>, IMaquinaRepository
        {
            public MotivoManutencaoRepository(RNContext db) : base(db)
            {

            }
        }
    
}
