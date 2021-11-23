using System.Collections.Generic;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.SecurityBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public class Customer : User
    {
        public string Phone { get; set; }
        public string Dni { get; set; }
    }
}