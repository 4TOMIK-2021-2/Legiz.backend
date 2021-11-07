using System.ComponentModel;

namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public enum ESpecialization
    {
        [Description("BL")]
        BusinessLaw = 1,
        [Description("RSL")]
        RealStateLaw = 2,
        [Description("CL")]
        CivilLaw = 3,
        [Description("CTL")]
        ConstructionLaw = 4,
        [Description("EL")]
        ElderLaw = 5
    }
}