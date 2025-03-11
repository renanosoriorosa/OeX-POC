using OeX.Management.Domain.Manutecoes;
using OeX.Management.Domain.Manutecoes.Interfaces;
using OeX.Management.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Infrastructure.Repository.Manutencoes
{
    public class ManutencaoRepository : Repository<Manutencao>, IManutencaoRepository
    {
        public ManutencaoRepository(RNContext db) : base(db)
        {

        }
    }
}
