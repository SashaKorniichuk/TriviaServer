using AutoMapper;
using Trivia.BLL.Models.DTO;
using Trivia.BLL.Services.Abstractions;
using Trivia.DAL.Entity;
using Trivia.DAL.Repositories.Abstractions;

namespace Trivia.BLL.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        private readonly IGenericRepository<Player> _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IGenericRepository<Player> playerRepository, IMapper mapper)
        {
            _playerRepository=playerRepository;
            _mapper=mapper;
        }

        public async Task<List<PlayerDTO>> GetLeaderBoardPlayers(int daysPeriod)
        {
            var response = new List<PlayerDTO>();

            await ExecuteQueriesAsync(async () =>
            {
                var players = await _playerRepository.GetAsync(x => x.LastGameDate>=DateTime.Now.AddDays(-daysPeriod));
                var playersDTO = _mapper.Map<IEnumerable<PlayerDTO>>(players).ToList();
                response=playersDTO;

            }, response);
            return response;
        }
    }
}
