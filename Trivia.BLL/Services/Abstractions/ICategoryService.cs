using Trivia.BLL.Models.DTO;

namespace Trivia.BLL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategories();
    }
}
