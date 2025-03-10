using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.Maquinas;
using OeX.Dashboard.Domain.Maquinas.Interfaces;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.Repository.Maquinas
{
    public class MaquinaRepository : IMaquinaRepository
    {
        private readonly RNContext _context;

        public MaquinaRepository(RNContext context)
        {
            _context = context;
        }

        public async Task<List<Maquina>> GetAll()
        {
            return await _context.Maquinas.ToListAsync();
        }
    }
}
