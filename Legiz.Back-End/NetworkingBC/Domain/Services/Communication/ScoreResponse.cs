using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.Shared.Domain.Services.Communication;

namespace Legiz.Back_End.NetworkingBC.Domain.Services.Communication
{
    public class ScoreResponse : BaseResponse<Score>
    {
        public ScoreResponse(string message) : base(message)
        {
        }

        public ScoreResponse(Score resource) : base(resource)
        {
        }
    }
}