namespace Travel.Services.Basket.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; } = null!;
        public string? DiscountCode { get; set; }
        public List<BasketItemDto>? basketItems { get; set; }
        public decimal TotalPrice
        {
            get => basketItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
