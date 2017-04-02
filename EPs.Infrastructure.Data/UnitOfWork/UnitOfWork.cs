using EPs.Domain.Core.Commands;
using EPs.Domain.Core.Interfaces;
using EPs.Infrastructure.Data.Contexts;

namespace EPs.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EPsContext _context;

        public UnitOfWork(EPsContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
