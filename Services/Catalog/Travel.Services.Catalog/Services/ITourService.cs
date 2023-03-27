using Travel.Services.Catalog.Dtos;
using Travel.Shared.Dtos;

namespace Travel.Services.Catalog.Services
{
    public interface ITourService
    {
        Task<Response<List<TourDto>>> GetAllAsync();
        Task<Response<TourDto>> GetByIdAsync(string id);
        Task<Response<List<TourDto>>> GetByUserIdAsync(string userid);
        Task<Response<TourDto>> CreateAsync(TourCreateDto tourCreateDto);
        Task<Response<NoContent>> UpdateAsync(TourUpdateDto tourUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
