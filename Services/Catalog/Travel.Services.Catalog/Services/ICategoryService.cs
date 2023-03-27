using Travel.Services.Catalog.Dtos;
using Travel.Services.Catalog.Models;
using Travel.Shared.Dtos;

namespace Travel.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
