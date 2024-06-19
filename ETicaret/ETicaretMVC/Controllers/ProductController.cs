using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
