using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.NetworkingBC.Domain.Models;

namespace Legiz.Back_End.NetworkingBC.Domain.Repository
{
    public interface IScoreRepository
    {
        Task<IEnumerable<Score>> ListAsync();
    }
}