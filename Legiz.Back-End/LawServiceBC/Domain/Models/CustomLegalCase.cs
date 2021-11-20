namespace Legiz.Back_End.LawServiceBC.Domain.Models
{
    public class CustomLegalCase : LawService
    {
        public string StartAt { get; set; }
        public string FinishAt { get; set; }
        public ETypeMeet TypeMeet { get; set; }
        public string LinkZoom { get; set; }
    }
}