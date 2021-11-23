namespace Legiz.Back_End.UserProfileBC.Domain.Services.Communication
{
    public class RegisterLawyerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string District { get; set; }
        public string University { get; set; }
        public int Specialization { get; set; }
        public int PriceLegalAdvice { get; set; }
        public int PriceCustomContract { get; set; }
        public int SubscriptionId { get; set; }
    }
}