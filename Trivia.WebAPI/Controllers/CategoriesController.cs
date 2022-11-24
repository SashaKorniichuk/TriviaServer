using Microsoft.AspNetCore.Mvc;
using Trivia.BLL.Models.DTO;
using Trivia.BLL.Models.ResponseApiModels;
using Trivia.BLL.Services.Abstractions;

namespace Trivia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService= categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
        {
           return await _categoryService.GetAllCategories();
        }
    }
}
