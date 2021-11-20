using System.ComponentModel;

namespace Legiz.Back_End.LawServiceBC.Domain.Models
{
    public enum EStatusLawService
    {
        [Description("C")]
        Complete = 1,
        [Description("P")]
        Process = 2
    }
}