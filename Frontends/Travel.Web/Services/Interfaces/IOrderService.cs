using Travel.Web.Models.Orders;

namespace Travel.Web.Services.Interfaces
{
	public interface IOrderService
	{
		Task<OrderCreatedViewModel> CreatOrder(CheckoutInfoInput checkoutInfoInput);
		Task SuspendOrder(CheckoutInfoInput checkoutInfoInput);
		Task<List<OrderViewModel>> GetOrder();
	}
}
