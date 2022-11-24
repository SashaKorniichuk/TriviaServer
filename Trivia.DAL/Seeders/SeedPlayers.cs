using Trivia.DAL.Entity;
using Trivia.DAL.Enums;

namespace Trivia.DAL.Seaders
{
    public partial class Seeder
    {
        private static async Task SeedPlayers(DataContext context)
        {
            if (!context.Players.Any())
            {                
                DateTime startDate = (DateTime.Now);
                startDate=startDate.AddMonths(-2);
                int range=(DateTime.Now - startDate).Days;

                var players = new List<Player>();

                for (int i = 1; i <= 100; i++)
                {
                    players.Add(CreatePlayer(i, startDate, range));
                }

                await context.Players.AddRangeAsync(players);
                await context.SaveChangesAsync();
            }
        }

        private static Player CreatePlayer(int playerIndex,DateTime startDate,int range)
        {
            Player newPlayer = new Player()
            {
                Name="Player "+ playerIndex,
                Score=random.Next(0, 700),
                LastGameDate=startDate.AddDays(random.Next(range)),
                IsGameOrganizer=false,
                CharacterColor="Red"
            };
            return newPlayer;
        }
    }
}
