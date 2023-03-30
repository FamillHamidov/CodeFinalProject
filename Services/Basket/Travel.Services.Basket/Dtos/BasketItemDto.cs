namespace Travel.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public string? TourName { get; set; }
        public string TourId { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
