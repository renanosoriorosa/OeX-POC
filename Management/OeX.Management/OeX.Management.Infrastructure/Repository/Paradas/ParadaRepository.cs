using OeX.Management.Domain.Paradas;
using OeX.Management.Domain.Paradas.Interfaces;
using OeX.Management.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Infrastructure.Repository.Paradas
{
    public class ParadaRepository : Repository<Parada>, IParadaRepository
    {
        public ParadaRepository(RNContext db) : base(db)
        {

        }
    }
}
