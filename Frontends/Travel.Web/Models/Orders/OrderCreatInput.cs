namespace Travel.Web.Models.Orders
{
	public class OrderCreatInput
	{
        public OrderCreatInput()
        {
			OrderItems = new List<OrderItemCreateInput>();
        }
        public string? BuyerId { get; set; }
		public List<OrderItemCreateInput>? OrderItems { get; set; }
		public AddressCreateInput? Address { get; set; }
	}
}
