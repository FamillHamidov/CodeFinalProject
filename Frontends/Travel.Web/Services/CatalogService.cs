using Travel.Shared.Dtos;
using Travel.Web.Helpers;
using Travel.Web.Models;
using Travel.Web.Models.Catalog;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Services
{
	public class CatalogService : ICatalogService
	{
		private readonly HttpClient _httpClient;
		private readonly IPhotoStockService _photoStockService;
		private readonly PhotoHelper _photoHelper;

		public CatalogService(HttpClient httpClient, IPhotoStockService photoStockService, PhotoHelper photoHelper)
		{
			_httpClient = httpClient;
			_photoStockService = photoStockService;
			_photoHelper = photoHelper;
		}

		public async Task<bool> CreateBTourAsync(TourCreateInput tourCreateInput)
		{
            var resultPhotoService = await _photoStockService.UploadPhoto(tourCreateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                tourCreateInput.StockPictureUrl = resultPhotoService.Url;
            }

            var response = await _httpClient.PostAsJsonAsync<TourCreateInput>("tours", tourCreateInput);
			return response.IsSuccessStatusCode;

		}

		public async Task<bool> DeleteTourAsync(string tourId)
		{
			var response = await _httpClient.DeleteAsync($"tours/{tourId}");
			return response.IsSuccessStatusCode;
		}

		public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
		{
			var response = await _httpClient.GetAsync("category");
			if (!response.IsSuccessStatusCode) { return null; }
			var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();
			return responseSuccess.Data;
		}

		public async Task<List<TourViewModel>> GetAllTourAsync()
		{
			var response = await _httpClient.GetAsync("tours");
			if (!response.IsSuccessStatusCode) { return null; }
			var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<TourViewModel>>>();
            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });
            return responseSuccess.Data;
		}

		public async Task<List<TourViewModel>> GetAllToursByUserIdAsync(string userId)
		{
			var response = await _httpClient.GetAsync($"tours/GetAllByUserId/{userId}");
			if (!response.IsSuccessStatusCode) { return null; }
			var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<TourViewModel>>>();
            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });
            return responseSuccess.Data;
		}

		public async Task<TourViewModel> GetByTourId(string tourId)
		{
			var response = await _httpClient.GetAsync($"tours/{tourId}");
			if (!response.IsSuccessStatusCode) { return null; }
			var responseSuccess = await response.Content.ReadFromJsonAsync<Response<TourViewModel>>();
			responseSuccess.Data.StockPictureUrl = _photoHelper.GetPhotoStockUrl(responseSuccess.Data.Picture);
			return responseSuccess.Data;
		}

		public async Task<bool> UpdateTourAsync(TourUpdateInput tourUpdateInput)
		{
			var response = await _httpClient.PutAsJsonAsync<TourUpdateInput>("tours", tourUpdateInput);
			return response.IsSuccessStatusCode;
		}
	}
}
