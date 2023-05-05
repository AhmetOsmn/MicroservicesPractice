using MicroservicesPractice.Services.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroservicesPractice.Services.Catalog.Dtos
{
    public class CourseDto
    {
        public string Id { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CategoryId { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public FeatureDto Feature { get; set; } = null!;
    }
}
