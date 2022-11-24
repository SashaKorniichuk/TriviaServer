using AutoMapper;
using Trivia.BLL.Models.DTO;
using Trivia.BLL.Services.Abstractions;
using Trivia.DAL.Entity;
using Trivia.DAL.Repositories.Abstractions;

namespace Trivia.BLL.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository= categoryRepository;
            _mapper= mapper;
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var response = new List<CategoryDTO>();

            await ExecuteQueriesAsync(async () =>
            {
                var categories = await _categoryRepository.GetAllAsync();
                var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories).ToList();
                response=categoriesDTO;
            }, response);
            return response;
        }
    }
}
