using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Travel.Services.Catalog.Models
{
    public class Tour
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price{ get; set; }
        public string? Luggage{ get; set; }
        public string? AirTicket { get; set; }
        public string? Picture{ get; set; }
        public string? UsserId { get; set; }
        public string? Description { get; set; }
        public Feature? Feature { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }
        [BsonIgnore]
        public Category? Category { get; set; }
    }
}
