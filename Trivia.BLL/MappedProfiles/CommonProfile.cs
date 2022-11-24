using AutoMapper;
using Trivia.BLL.Models.DTO;
using Trivia.DAL.Entity;

namespace Trivia.BLL.MappedProfiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Answer, AnswerDTO>();
            CreateMap<Question, QuestionDTO>();
            CreateMap<Player, PlayerDTO>()
                .ForMember(dest => dest.ConnectionId, opt => opt.Ignore());
        }
    }
}
