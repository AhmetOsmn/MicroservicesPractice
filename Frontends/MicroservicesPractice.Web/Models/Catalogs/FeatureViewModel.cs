using System.ComponentModel.DataAnnotations;

namespace MicroservicesPractice.Web.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs Süresi")]
        public int Duration { get; set; }
    }
}
