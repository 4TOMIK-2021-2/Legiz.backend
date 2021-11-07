using System.Threading.Tasks;

namespace Legiz.Back_End.UserProfileBC.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}