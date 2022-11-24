using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Cryptography;
using System.Text;
using Trivia.BLL.Services.Abstractions;
using Trivia.DAL.Entity;
using Trivia.DAL.Repositories.Abstractions;

namespace Trivia.BLL.Services
{
    public class TriviaHubService : BaseService, ITriviaHubService
    {
        private readonly IGenericRepository<Player> _playerRepository;
        private readonly IGenericRepository<GameplayRoom> _gameplayRoomRepository;

        public TriviaHubService(IGenericRepository<Player> playerRepository, IGenericRepository<GameplayRoom> gameplayRoomRepository)
        {
            _playerRepository= playerRepository;
            _gameplayRoomRepository= gameplayRoomRepository;
        }

        public async Task Join(Hub hub, string characterColor)
        {
            var connectionId = hub.Context.ConnectionId;

            var player = (await _playerRepository.GetAsync(x => x.ConnectionId==connectionId)).FirstOrDefault();

            if (player is null)
            {
                Player newPlayer = new Player()
                {
                    Score=0,
                    CharacterColor=characterColor,
                    IsGameOrganizer=false,
                    ConnectionId=connectionId,
                    LastGameDate=DateTime.Now,
                    Name="Player_"+RandomString(6)
                };

                await _playerRepository.CreateAsync(newPlayer);

                player=newPlayer;
            }
            else
            {
                player.ConnectionId=connectionId;
                player.CharacterColor=characterColor;
                await _playerRepository.UpdateAsync(player);
            }

            var gameRoom = (await _gameplayRoomRepository.GetAsync(x => x.Players.Count<x.MaxPlayers)).FirstOrDefault();

            if (gameRoom is null)
            {
                GameplayRoom room = new GameplayRoom();
                room.MaxPlayers=2;
                room.Players=new List<Player>() { player };

                player.IsGameOrganizer=true;

                await _gameplayRoomRepository.CreateAsync(room);
                await _playerRepository.UpdateAsync(player);

                await hub.Groups.AddToGroupAsync(connectionId, room.Id.ToString());
            }
            else
            {
                string gameRoomId = gameRoom.Id.ToString();

                player.GameplayRoomId=gameRoom.Id;
                player.IsGameOrganizer=false;

                await _playerRepository.UpdateAsync(player);

                await hub.Groups.AddToGroupAsync(connectionId, gameRoomId);

                var opponent = (await _playerRepository.GetAsync(x => x.ConnectionId!=connectionId&&x.GameplayRoomId==player.GameplayRoomId)).FirstOrDefault();

                if (opponent is null)
                {
                    return;
                }

                await hub.Clients.Group(gameRoomId).SendAsync("OpponentJoined", opponent.Name, opponent.CharacterColor.ToString(), opponent.IsGameOrganizer);
                await hub.Clients.OthersInGroup(gameRoomId).SendAsync("OpponentJoined", player.Name, player.CharacterColor.ToString(), player.IsGameOrganizer);

                await hub.Clients.Group(gameRoomId).SendAsync("CanPlay");
            }

        }
        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task Send(Hub hub, string json)
        {
            var connectionId = hub.Context.ConnectionId;

            var player = (await _playerRepository.GetAsync(x => x.ConnectionId==connectionId)).FirstOrDefault();

            if (player is null)
            {
                return;
            }

            await hub.Clients.OthersInGroup(player.GameplayRoomId.ToString()).SendAsync("Send", json);
        }

        public async Task Leave(Hub hub)
        {
            var connectionId = hub.Context.ConnectionId;
            var player = (await _playerRepository.GetAsync(x => x.ConnectionId==connectionId)).FirstOrDefault();
           
            if (player is null || player.GameplayRoomId is null)
            {
                return;
            }

            var gameRoom = await _gameplayRoomRepository.GetAsync(player.GameplayRoomId.Value);

            if (gameRoom is null)
            {
                return;
            }

            var players = (await _playerRepository.GetAsync(x => x.GameplayRoomId==gameRoom.Id)).ToList();

            for (int i = 0; i < players.Count; i++)
            {
                players[i].GameplayRoomId=null;
                await _playerRepository.UpdateAsync(players[i]);
            }
            
            await hub.Clients.OthersInGroup(gameRoom.Id.ToString()).SendAsync("OpponentLeave");
            await hub.Groups.RemoveFromGroupAsync(connectionId,gameRoom.Id.ToString());
            await _gameplayRoomRepository.RemoveAsync(gameRoom);
        }
    }
}
