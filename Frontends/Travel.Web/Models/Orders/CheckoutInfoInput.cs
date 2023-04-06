namespace Travel.Web.Models.Orders
{
	public class CheckoutInfoInput
	{
		public string? Province { get; set; }
		public string? District { get; set; }
		public string? Street { get; set; }
		public string? ZipCode { get; set; }
		public string? Line { get; set; }
		public string CardName { get; set; } = null!;
		public string CardNumber { get; set; } = null!;
		public string CVV { get; set; } = null!;
		public string Expiration { get; set; } = null!;
	}
}
