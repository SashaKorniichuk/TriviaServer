namespace Trivia.BLL.Models.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public IEnumerable<AnswerDTO> Answers { get; set; }
    }
}
