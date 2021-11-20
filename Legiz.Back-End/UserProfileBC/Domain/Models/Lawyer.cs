namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public class Lawyer : User
    {
        public string LawyerName { get; set; }
        public string LawyerLastName { get; set; }
        public string District { get; set; }
        public string University { get; set; }
        public ESpecialization Specialization { get; set; }
        public int PriceLegalAdvice { get; set; }
        public int PriceCustomContract { get; set; }
        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }
    }
}