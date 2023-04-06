namespace Travel.Web.Models.Catalog
{
	public class TourViewModel
	{
		public string? Id { get; set; }
		public string Name { get; set; } = null!;

		public decimal Price { get; set; }
		public string Luggage { get; set; } = null!;
        public string AirTicket { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string StockPictureUrl { get; set; } = null!;
        public string? UserId { get; set; }
		public string Description { get; set; } = null!;
        public string? CategoryId { get; set; }
		public FeatureViewModel? Feature { get; set; }
		public CategoryViewModel? Category { get; set; }
	}
}
