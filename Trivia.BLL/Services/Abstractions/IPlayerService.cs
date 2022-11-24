using Trivia.BLL.Models.DTO;

namespace Trivia.BLL.Services.Abstractions
{
    public interface IPlayerService
    {
        Task<List<PlayerDTO>> GetLeaderBoardPlayers(int daysPeriod);
    }
}
