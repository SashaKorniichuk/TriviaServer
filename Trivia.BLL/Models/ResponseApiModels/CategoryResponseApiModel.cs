using Trivia.BLL.Helpers;
using Trivia.BLL.Models.DTO;

namespace Trivia.BLL.Models.ResponseApiModels
{
    public class CategoryResponseApiModel : BaseResponse
    {
        public CategoryResponseApiModel()
        {
            Status=ResponseStatus.Success;
        }
        public List<CategoryDTO>? Categories { get; set; }
    }
}
