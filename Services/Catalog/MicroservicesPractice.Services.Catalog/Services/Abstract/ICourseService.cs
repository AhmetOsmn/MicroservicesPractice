using MicroservicesPractice.Services.Catalog.Dtos;
using MicroservicesPractice.Shared.Dtos;

namespace MicroservicesPractice.Services.Catalog.Services.Abstract
{
    public interface ICourseService
    {
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
    }
}