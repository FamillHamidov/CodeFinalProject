using Travel.Web.Models.Catalog;

namespace Travel.Web.Services.Interfaces
{
	public interface ICatalogService
	{
		Task<List<TourViewModel>> GetAllTourAsync();
		Task<List<CategoryViewModel>> GetAllCategoryAsync();
		Task<List<TourViewModel>> GetAllToursByUserIdAsync(string userId);
		Task<TourViewModel> GetByTourId(string tourId);
		Task<bool> CreateBTourAsync(TourCreateInput tourCreateInput);
		Task<bool> UpdateTourAsync(TourUpdateInput tourUpdateInput);
		Task<bool> DeleteTourAsync(string tourId);	
	}
}
