﻿namespace Travel.Web.Models.Catalog
{
	public class TourCreateInput
	{
		public string? Name { get; set; }

		public decimal Price { get; set; }
		public string? Luggage { get; set; }
		public string? AirTicket { get; set; }
		public string? UserId { get; set; }
		public string? Description { get; set; }
		public string? Picture { get; set; }
		public string? StockPictureUrl { get; set; }
		public FeatureViewModel? Feature { get; set; }
		public string? CategoryId { get; set; }
		public IFormFile PhotoFormFile { get; set; }
	}
}
