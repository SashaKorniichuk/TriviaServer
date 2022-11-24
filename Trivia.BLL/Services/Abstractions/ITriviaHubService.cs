using Microsoft.AspNetCore.SignalR;

namespace Trivia.BLL.Services.Abstractions
{
    public interface ITriviaHubService
    {
        Task Join(Hub hub, string characterColor);
        Task Send(Hub hub, string json);
        Task Leave(Hub hub);
    }
}
