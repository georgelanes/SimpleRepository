using System.Threading.Tasks;

namespace SimpleRepository.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}