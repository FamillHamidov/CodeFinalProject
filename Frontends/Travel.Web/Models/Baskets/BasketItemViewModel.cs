namespace Travel.Web.Models.Baskets
{
	public class BasketItemViewModel
	{
		public int Quantity { get; set; } = 1;

		public string TourId { get; set; } = null!;
		public string TourName { get; set; }=null!;

		public decimal Price { get; set; }

		private decimal? DiscountAppliedPrice;

		public decimal GetCurrentPrice
		{
			get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price;
		}

		public void AppliedDiscount(decimal discountPrice)
		{
			DiscountAppliedPrice = discountPrice;
		}
	}
}
