namespace Legiz.Back_End.UserProfileBC.Resources
{
    public class LawyerSubscriptionResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string District { get; set; }
        public string University { get; set; }
        public string Specialization { get; set; }
        public float PriceLegalAdvice { get; set; }
        public float PriceCustomContract { get; set; }
        public SubscriptionResource Subscription { get; set; }
    }
}