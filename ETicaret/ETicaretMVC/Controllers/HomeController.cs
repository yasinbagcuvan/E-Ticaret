using ETicaretMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ViewModels;

namespace ETicaretMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            ViewBag.TokenAuth = HttpContext.Session.GetString("TokenAuth");

            return View();
        }
        public IActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7035/"); //Api url

            model.AppUserId = Convert.ToInt32(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);//Login olmuþ kullanicinin User bilgisinde alacaðýz

            string modelJson = JsonSerializer.Serialize(model);

            StringContent content = new StringContent(modelJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync("/api/Categories", content);

            if (responseMessage != null && responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // Burada kayit yapildi ve gerekli aksiyon sonrasi bir yere yönlendirme yapilabilri.

                TempData["RecordMessage"] = "Kayit yapilmiþtir.";
                TempData["RecordStatus"] = true;

                return RedirectToAction(nameof(Index));
            }


            ViewData["RecordMessage"] = "Kayit yapilamamýþtýr.";
            ViewData["RecordStatus"] = false;

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
