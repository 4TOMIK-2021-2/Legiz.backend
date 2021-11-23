﻿namespace Legiz.Back_End.UserProfileBC.Resources
{
    public class LawyerResource
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LawyerName { get; set; }
        public string LawyerLastName { get; set; }
        public string District { get; set; }
        public string University { get; set; }
        public string Specialization { get; set; }
        public float PriceLegalAdvice { get; set; }
        public float PriceCustomContract { get; set; }
        public int SubscriptionId { get; set; }
    }
}