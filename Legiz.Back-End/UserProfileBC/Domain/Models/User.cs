using System.Collections.Generic;
using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        
        public IList<CustomLegalCase> CustomLegalCases { get; set; } = new List<CustomLegalCase>();

        public IList<LegalAdvice> LegalAdvices { get; set; } = new List<LegalAdvice>();
    }
}