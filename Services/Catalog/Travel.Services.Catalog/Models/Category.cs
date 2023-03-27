using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Travel.Services.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string? Name{ get; set; }
    }
}
