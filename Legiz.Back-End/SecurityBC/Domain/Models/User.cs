using System.Collections.Generic;
using System.Text.Json.Serialization;
using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.SecurityBC.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string UserType { get; set; }
        
        public IList<CustomLegalCase> CustomLegalCases { get; set; } = new List<CustomLegalCase>();

        public IList<LegalAdvice> LegalAdvices { get; set; } = new List<LegalAdvice>();
    }
}