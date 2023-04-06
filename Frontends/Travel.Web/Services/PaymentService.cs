using System.Net.Http;
using Travel.Web.Models.FakePayment;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Services
{

	public class PaymentService : IPaymentService
	{
		private readonly HttpClient _httpClient;

		public PaymentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		public async Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
		{
			var response = await _httpClient.PostAsJsonAsync<PaymentInfoInput>("fakepayments", paymentInfoInput);
			return response.IsSuccessStatusCode;
		}
	}
}
