using System.Threading.Tasks;

namespace Legiz.Back_End.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}