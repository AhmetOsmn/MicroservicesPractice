using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MicroservicesPractice.Web.Models.Catalogs
{
    public class CourseUpdateInput
    {
        public string Id { get; set; } = null!;

        [Display(Name = "Kurs ismi")]
        [Required]
        public string Name { get; set; } = null!;

        [Display(Name = "Açıklama")]        
        public string Description { get; set; } = null!;
        public string? Picture { get; set; }

        [Display(Name = "Kurs fiyat")]
        [Required]
        public decimal Price { get; set; }
        public string UserId { get; set; } = null!;

        [Display(Name = "Kurs kategori")]
        [Required]
        public string CategoryId { get; set; } = null!;
        public FeatureViewModel Feature { get; set; } = null!;

        [Display(Name = "Kurs Resim")]
        public IFormFile? PhotoFormFile { get; set; }
    }
}
