using Microsoft.AspNetCore.Mvc;
using Travel.Web.Models.Baskets;
using Travel.Web.Models.Discounts;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Controllers
{
	public class BasketController : Controller
	{
		private readonly ICatalogService _catalogService;
		private readonly IBasketService _basketService;

		public BasketController(ICatalogService catalogService, IBasketService basketService)
		{
			_catalogService = catalogService;
			_basketService = basketService;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _basketService.Get());
		}

		public async Task<IActionResult> AddBasketItem(string tourId)
		{
			var tour = await _catalogService.GetByTourId(tourId);

			var basketItem = new BasketItemViewModel { TourId = tour.Id, TourName = tour.Name, Price = tour.Price };

			await _basketService.AddBasketItem(basketItem);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> RemoveBasketItem(string tourId)
		{
			var result = await _basketService.RemoveBasketItem(tourId);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
		{
			if (!ModelState.IsValid)
			{
				TempData["discountError"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).First();
				return RedirectToAction(nameof(Index));
			}
			var discountStatus = await _basketService.ApplyDiscount(discountApplyInput.Code);

			TempData["discountStatus"] = discountStatus;
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> CancelApplyDiscount()
		{
			await _basketService.CancelApplyDiscount();
			return RedirectToAction(nameof(Index));
		}
	}
}
