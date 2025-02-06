using OeX.Auth.Domain.Common;
using OeX.Auth.Infrastructure.Context;

namespace OeX.Auth.Infrastructure.UoW
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
