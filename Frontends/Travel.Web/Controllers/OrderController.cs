﻿using Microsoft.AspNetCore.Mvc;
using Travel.Web.Models.Orders;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IBasketService _basketService;
		private readonly IOrderService _orderService;

		public OrderController(IBasketService basketService, IOrderService orderService)
		{
			_basketService = basketService;
			_orderService = orderService;
		}

		public async Task<IActionResult> Checkout()
		{
			var basket = await _basketService.Get();

			ViewBag.basket = basket;
			return View(new CheckoutInfoInput());
		}
		[HttpPost]
		public async Task<IActionResult> Checkout(CheckoutInfoInput checkoutInfoInput)
		{
			var orderStatus = await _orderService.CreatOrder(checkoutInfoInput);
			if (!orderStatus.IsSuccessful)
			{
				var basket = await _basketService.Get();

				ViewBag.basket = basket;

				ViewBag.error = orderStatus.Error;

				return View();
			}
			return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = orderStatus.OrderId });
		}
		public IActionResult SuccessfulCheckout(int orderId)
		{
			ViewBag.orderId = orderId;
			return View();
		}
	}
}
