using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Travel.Shared.Services;
using Travel.Web.Models.Catalog;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Controllers
{
    [Authorize]
    public class ToursController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public ToursController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAllToursByUserIdAsync(_sharedIdentityService.GetUserId));
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TourCreateInput tourCreateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            tourCreateInput.UserId = _sharedIdentityService.GetUserId;
            await _catalogService.CreateBTourAsync(tourCreateInput);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(string id)
        {
            var tour = await _catalogService.GetByTourId(id);
            var categories = await _catalogService.GetAllCategoryAsync();
            if (tour == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name", tour.Id);
            TourUpdateInput tourUpdateInput = new()
            {
                CategoryId = tour.Id,
                UserId = tour.UserId,
                Name = tour.Name,
                AirTicket = tour.AirTicket,
                Luggage = tour.Luggage,
                Price = tour.Price,
                Description = tour.Description,
                Picture = tour.Picture,
                Feature = tour.Feature
            };
            return View(tourUpdateInput);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TourUpdateInput tourUpdateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name", tourUpdateInput.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _catalogService.UpdateTourAsync(tourUpdateInput);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteTourAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
