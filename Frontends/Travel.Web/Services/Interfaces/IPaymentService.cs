using Travel.Web.Models.FakePayment;

namespace Travel.Web.Services.Interfaces
{
	public interface IPaymentService
	{
		Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
	}
}
