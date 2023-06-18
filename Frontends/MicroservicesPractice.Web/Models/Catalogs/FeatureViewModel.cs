using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MicroservicesPractice.Web.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Required]
        [Display(Name = "Kurs Süresi")]
        public int Duration { get; set; }
    }
}
