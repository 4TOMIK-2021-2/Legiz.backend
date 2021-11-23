using System.ComponentModel;

namespace Legiz.Back_End.LawServiceBC.Domain.Models
{
    public enum ETypeMeet
    {
        [Description("O")]
        Online = 1,
        [Description("P")]
        FaceToFace = 2
    }
}