using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicesPractice.Services.Catalog.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(BsonType.Decimal128)]
        public Decimal Price { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = null!;

        [BsonIgnore]
        public Category Category { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public Feature Feature { get; set; } = null!;
    }
}
