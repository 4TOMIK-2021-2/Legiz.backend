using System.Collections.Generic;
using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public class Customer : User
    {
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        
    }
}