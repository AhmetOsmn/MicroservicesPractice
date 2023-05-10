using MicroservicesPractice.Services.Catalog.Dtos;
using MicroservicesPractice.Services.Catalog.Services.Abstract;
using MicroservicesPractice.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPractice.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return CreateActionResultInstance(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var categories = await _categoryService.GetByIdAsync(id);

            return CreateActionResultInstance(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            var response = await _categoryService.CreateAsync(categoryCreateDto);

            return CreateActionResultInstance(response);
        }
    }
}
