namespace MicroservicesPractice.Services.Catalog.Dtos
{
    public class CourseCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Picture { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
        public FeatureDto Feature { get; set; } = null!;
    }
}
