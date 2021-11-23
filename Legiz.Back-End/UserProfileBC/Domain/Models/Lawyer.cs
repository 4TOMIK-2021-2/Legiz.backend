using Legiz.Back_End.SecurityBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public class Lawyer : User
    {
        public string District { get; set; }
        public string University { get; set; }
        public ESpecialization Specialization { get; set; }
        public int PriceLegalAdvice { get; set; }
        public int PriceCustomContract { get; set; }
        
        // Relationship
        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }
    }
}