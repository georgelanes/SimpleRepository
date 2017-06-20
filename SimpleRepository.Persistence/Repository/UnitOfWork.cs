using SimpleRepository.Core.Interfaces;
using SimpleRepository.Persistence.Context;
using System.Threading.Tasks;

namespace SimpleRepository.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
