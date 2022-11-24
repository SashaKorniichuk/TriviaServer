using Microsoft.AspNetCore.SignalR;
using Trivia.BLL.Services.Abstractions;

namespace Trivia.WebAPI.Hubs
{
    
    public class TriviaHub : Hub
    {
        private readonly ITriviaHubService _triviaHubService;

        public TriviaHub(ITriviaHubService triviaHubService)
        {
            _triviaHubService=triviaHubService;
        }

        public async Task Join(string characterColor)
        {            
            await _triviaHubService.Join(this,characterColor);
        }
        public async Task Send(string json)
        {
            await _triviaHubService.Send(this, json);
        }

        public async Task Leave()
        {
            await _triviaHubService.Leave(this);
        }
        
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override async Task<Task> OnDisconnectedAsync(Exception? exception)
        {
            await _triviaHubService.Leave(this);
            return base.OnDisconnectedAsync(exception);
        }
        
    }
}
