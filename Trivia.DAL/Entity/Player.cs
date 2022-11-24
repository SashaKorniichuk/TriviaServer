using System.ComponentModel.DataAnnotations;
using Trivia.DAL.Enums;

namespace Trivia.DAL.Entity
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime LastGameDate { get; set; }
        public bool IsGameOrganizer { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
        public string CharacterColor { get; set; } = string.Empty;
        public int? GameplayRoomId { get; set; }
        public GameplayRoom? GameplayRoom { get; set; }
    }
}
