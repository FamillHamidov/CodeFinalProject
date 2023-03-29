using Travel.Services.Catalog.Models;

namespace Travel.Services.Catalog.Dtos
{
    public class TourCreateDto
    {
        public string? Name { get; set; } 

        public decimal Price { get; set; }
        public string? Luggage { get; set; }
        public string? AirTicket { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public FeatureDto? Feature{ get; set; }
        public string? CategoryId { get; set; }
    }
}
