using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MicroservicesPractice.Web.Models.Catalogs
{
    public class CourseUpdateInput
    {
        public string Id { get; set; } 

        [Display(Name = "Kurs ismi")]
        public string? Name { get; set; }

        [Display(Name = "Açıklama")]        
        public string? Description { get; set; }

        public string? Picture { get; set; }

        [Display(Name = "Kurs fiyat")]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Kurs kategori")]
        public string CategoryId { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Kurs Resim")]
        public IFormFile? PhotoFormFile { get; set; }
    }
}
