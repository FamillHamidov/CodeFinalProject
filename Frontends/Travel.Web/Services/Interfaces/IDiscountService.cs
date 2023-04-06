using Travel.Web.Models.Discounts;

namespace Travel.Web.Services.Interfaces
{
	public interface IDiscountService
	{
		Task<DiscountViewModel> GetDiscount(string code);
	}
}
