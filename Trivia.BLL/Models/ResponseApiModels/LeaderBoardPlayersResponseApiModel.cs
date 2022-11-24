using Trivia.BLL.Helpers;
using Trivia.BLL.Models.DTO;

namespace Trivia.BLL.Models.ResponseApiModels
{
    public class LeaderBoardPlayersResponseApiModel : BaseResponse
    {
        public LeaderBoardPlayersResponseApiModel()
        {
            Status=ResponseStatus.Success;
        }
        public IEnumerable<PlayerDTO> Players { get; set; }
    }
}
