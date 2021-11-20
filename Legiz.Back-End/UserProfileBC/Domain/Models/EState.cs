using System.ComponentModel;

namespace Legiz.Back_End.UserProfileBC.Domain.Models
{
    public enum EState
    {
        [Description("C")]
        Current = 1,
        [Description("")]
        Past = 2,
    }
}