using Microsoft.AspNetCore.Mvc;
using Travel.Web.Models;
using Travel.Web.Services;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IIdentityService _identityService;
		private readonly IRegisterService _registerService;

		public AuthController(IIdentityService identityService, IRegisterService registerService)
		{
			_identityService = identityService;
			_registerService = registerService;	
		}

		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInInput signInInput)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var response = await _identityService.SignIn(signInInput);
			if (!response.IsSuccessful)
			{
				response.Errors.ForEach(x =>
				{
					ModelState.AddModelError(String.Empty, x);
				});
				return View();
			}
			return RedirectToAction(nameof(Index),"Home");
		}
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpInput signUpInput)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var response = await _registerService.SignUp(signUpInput);
			if (!response)
			{
				return View();
			}
			return RedirectToAction(nameof(SignIn), "Auth");

		}

	}
}
