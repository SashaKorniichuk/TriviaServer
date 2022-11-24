using AutoMapper;
using Trivia.BLL.Models.DTO;
using Trivia.BLL.Models.ResponseApiModels;
using Trivia.BLL.Services.Abstractions;
using Trivia.DAL.Entity;
using Trivia.DAL.Repositories.Abstractions;

namespace Trivia.BLL.Services
{
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IGenericRepository<Question> _questionRepository;
        private readonly IGenericRepository<Answer> _answerRepository;
        private readonly IMapper _mapper;

        public QuestionService(IGenericRepository<Question> questionRepository, IMapper mapper, IGenericRepository<Answer> answerRepository)
        {
            _questionRepository= questionRepository;
            _mapper= mapper;
            _answerRepository=answerRepository;
        }


        public async Task<QuestionByCategoryIdResponseApiModel> GetQuestionByCategoryId(int categoryId)
        {
            var response = new QuestionByCategoryIdResponseApiModel();

            await ExecuteQueriesWithHandledExceptionsAsync(async () =>
            {
                Random random = new Random();

                var questions = await _questionRepository.GetAsync(x => x.CategoryId.Equals(categoryId));
                var count = questions.ToList().Count();

                if (count==0)
                {
                    response.ToFailed("Category not found");
                    return;
                }

                var question = questions.ToList()[random.Next(0, count)];

                var answers = await _answerRepository.GetAsync(x => x.QuestionId==question.Id);
                var answerDTO = _mapper.Map<IEnumerable<AnswerDTO>>(answers);

                response.Id= question.Id;
                response.Text=question.Text;
                response.Answers=answerDTO;

            }, response);
            return response;
        }
    }
}
