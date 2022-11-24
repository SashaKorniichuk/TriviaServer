using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trivia.DAL.Entity
{
    public class GameplayRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MaxPlayers { get; set; }
        public ICollection<Player>? Players { get; set; }
    }
}
