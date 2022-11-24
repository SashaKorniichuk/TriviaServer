using Microsoft.AspNetCore.Mvc;
using Trivia.BLL.Models.ResponseApiModels;
using Trivia.BLL.Services.Abstractions;

namespace Trivia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService= questionService;
        }

        [HttpGet("By_Category/{categoryId}")]
        public async Task<ActionResult<QuestionByCategoryIdResponseApiModel>> GetQuestionByCategoryId(int categoryId)
        {
            return await _questionService.GetQuestionByCategoryId(categoryId);
        }
    }
}
