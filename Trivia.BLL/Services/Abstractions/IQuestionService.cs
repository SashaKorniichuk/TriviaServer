using Trivia.BLL.Models.ResponseApiModels;

namespace Trivia.BLL.Services.Abstractions
{
    public interface IQuestionService
    {
        Task<QuestionByCategoryIdResponseApiModel> GetQuestionByCategoryId(int categoryId);
    }
}
