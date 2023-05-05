using MicroservicesPractice.Services.Catalog.Dtos;
using MicroservicesPractice.Services.Catalog.Models;
using MicroservicesPractice.Shared.Dtos;

namespace MicroservicesPractice.Services.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}