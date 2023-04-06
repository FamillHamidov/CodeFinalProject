using Travel.Shared.Dtos;
using Travel.Shared.Services;
using Travel.Web.Models.FakePayment;
using Travel.Web.Models.Orders;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Services
{
	public class OrderService : IOrderService
	{
		private readonly HttpClient _httpClient;
		private readonly IPaymentService _paymentService;
		private readonly IBasketService _basketService;
		private readonly ISharedIdentityService _sharedIdentityService;

		public OrderService(HttpClient httpClient, IPaymentService paymentService, IBasketService basketService, ISharedIdentityService sharedIdentityService)
		{
			_httpClient = httpClient;
			_paymentService = paymentService;
			_basketService = basketService;
			_sharedIdentityService = sharedIdentityService;
		}

		public async Task<OrderCreatedViewModel> CreatOrder(CheckoutInfoInput checkoutInfoInput)
		{
			var basket = await _basketService.Get();

			var paymentInfoInput = new PaymentInfoInput()
			{
				CardName = checkoutInfoInput.CardName,
				CardNumber = checkoutInfoInput.CardNumber,
				Expiration = checkoutInfoInput.Expiration,
				CVV = checkoutInfoInput.CVV,
				TotalPrice = basket.TotalPrice
			};
			var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);

			if (!responsePayment)
			{
				return new OrderCreatedViewModel() { Error = "Ödeme alınamadı", IsSuccessful = false };
			}

			var orderCreateInput = new OrderCreatInput()
			{
				BuyerId = _sharedIdentityService.GetUserId,
				Address = new AddressCreateInput { Province = checkoutInfoInput.Province, District = checkoutInfoInput.District, Street = checkoutInfoInput.Street, Line = checkoutInfoInput.Line, ZipCode = checkoutInfoInput.ZipCode },
			};

			basket.BasketItems.ForEach(x =>
			{
				var orderItem = new OrderItemCreateInput
				{
					TourId = x.TourId,
					Price = x.GetCurrentPrice,
					TourName = x.TourName
				};
				orderCreateInput.OrderItems.Add(orderItem);
			});

			var response = await _httpClient.PostAsJsonAsync<OrderCreatInput>("orders", orderCreateInput);

			if (!response.IsSuccessStatusCode)
			{
				return new OrderCreatedViewModel() { Error = "Sipariş oluşturulamadı", IsSuccessful = false };
			}

			var orderCreatedViewModel = await response.Content.ReadFromJsonAsync<Response<OrderCreatedViewModel>>();

			orderCreatedViewModel.Data.IsSuccessful = true;
			await _basketService.Delete();
			return orderCreatedViewModel.Data;
		}

		public async Task<List<OrderViewModel>> GetOrder()
		{
			var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("orders");

			return response.Data;
		}

		public Task SuspendOrder(CheckoutInfoInput checkoutInfoInput)
		{
			throw new NotImplementedException();
		}
	}
}
