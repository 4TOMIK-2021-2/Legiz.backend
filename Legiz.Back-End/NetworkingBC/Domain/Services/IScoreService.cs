using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.NetworkingBC.Domain.Models;

namespace Legiz.Back_End.NetworkingBC.Domain.Services
{
    public interface IScoreService
    {
        Task<IEnumerable<Score>> ListAsync();
    }
}