using OeX.Auth.Domain.Common;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RNContext _context;

        public UnitOfWork(RNContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
