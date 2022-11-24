using Microsoft.AspNetCore.Mvc;
using Trivia.BLL.Models.DTO;
using Trivia.BLL.Models.ResponseApiModels;
using Trivia.BLL.Services.Abstractions;

namespace Trivia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService= playerService;
        }

        [HttpGet("leaderboard/{daysPeriod}")]
        public async Task<ActionResult<List<PlayerDTO>>> GetLeaderBoardPlayers(int daysPeriod)
        {
            return await _playerService.GetLeaderBoardPlayers(daysPeriod);
        }
    }
}
