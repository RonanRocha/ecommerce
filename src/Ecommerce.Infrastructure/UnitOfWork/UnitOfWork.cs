using Eccomerce.Domain.UnitOfWork;
using Ecommerce.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _ctx;

        public UnitOfWork(AppDataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> Commit()
        {
            var success = (await _ctx.SaveChangesAsync()) > 0;
            return success;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
