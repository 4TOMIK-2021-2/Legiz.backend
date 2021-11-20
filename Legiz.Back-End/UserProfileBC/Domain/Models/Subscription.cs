using System.Collections.Generic;

namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public EState State { get; set; }
        public IList<Lawyer> Lawyers { get; set; } = new List<Lawyer>();
    }
}