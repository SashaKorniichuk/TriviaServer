namespace Trivia.BLL.Models.DTO
{
    public class PlayerDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime LastGameDate { get; set; }
        public bool IsGameOrganizer { get; set; }
        public Guid ConnectionId { get; set; }
        public string CharacterColor { get; set; } = string.Empty;
    }
}
