using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travel.Shared.Services;
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
	}
}
