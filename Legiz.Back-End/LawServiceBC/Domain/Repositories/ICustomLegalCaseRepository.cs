using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.LawServiceBC.Domain.Repositories
{
    public interface ICustomLegalCaseRepository
    {
        Task<IEnumerable<CustomLegalCase>> ListAsync();
        Task AddAsync(CustomLegalCase customLegalCase);
        Task<CustomLegalCase> FindByIdAsync(int id);
        void Update(CustomLegalCase customLegalCase);
    }
}