using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPractice.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
