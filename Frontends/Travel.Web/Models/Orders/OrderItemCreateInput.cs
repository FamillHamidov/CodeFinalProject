namespace Travel.Web.Models.Orders
{
	public class OrderItemCreateInput
	{
		public string? TourId { get; set; }
		public string? TourName { get; set; }
		public int Count { get; set; }
		public Decimal Price { get; set; }
	}
}
