using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trivia.DAL.Entity
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public ICollection<Answer>? Answers { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
