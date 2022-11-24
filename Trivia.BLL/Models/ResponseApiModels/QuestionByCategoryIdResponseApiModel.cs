using Trivia.BLL.Helpers;
using Trivia.BLL.Models.DTO;

namespace Trivia.BLL.Models.ResponseApiModels
{
    public class QuestionByCategoryIdResponseApiModel : BaseResponse
    {
        public QuestionByCategoryIdResponseApiModel()
        {
            Status=ResponseStatus.Success;
        }
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public IEnumerable<AnswerDTO> Answers { get; set; }
    }
}
