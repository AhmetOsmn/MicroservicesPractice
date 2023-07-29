using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicesPractice.Services.Catalog.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        [BsonRepresentation(BsonType.Decimal128)]
        public Decimal Price { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } 

        [BsonIgnore]
        public Category Category { get; set; } 

        public string Name { get; set; } 
        public string? Picture { get; set; }
        public string Description { get; set; } 
        public string UserId { get; set; } 
        public Feature Feature { get; set; } 
    }
}
