using ETicaretMVC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ViewModels;

namespace ETicaretMVC.Controllers
{

    [Authorize]
    public class CategoryController : Controller
    {
        private HttpClient _httpClient;

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        // GET: CategoryController
        [BreadCrumbActionFilter(Title = "Kategoriler")]
        public async Task<ActionResult> Index()
        {
            {
                //HttpClient httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri("https://localhost:7029/"); //Api url

                HttpResponseMessage responseMessage = await _httpClient.GetAsync("/api/Categories/listele");

                List<CategoryViewModel> list = new List<CategoryViewModel>();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseData))
                    {
                        list = JsonConvert.DeserializeObject<List<CategoryViewModel>>(responseData);
                    }
                    else
                    {
                        // JSON verisi boş
                        throw new Exception("Yanıt boş JSON verisi içeriyor.");
                    }
                }

                if (TempData.ContainsKey("RecordStatus"))
                {
                    ViewBag.RecordStatus = TempData["RecordStatus"];
                    ViewData["RecordMessage"] = TempData["RecordMessage"];
                }

                return View(list);
            }
        }


            // GET: CategoryController/Create
            [BreadCrumbActionFilter(Title = "Kategoriler@Index|Yeni Kategori")]
        public ActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();

            return View(model);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryViewModel model)
        {
            //HttpClient httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("https://localhost:7029/"); //Api url

            model.AppUserId = Convert.ToInt32(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);//Login olmuş kullanicinin User bilgisinde alacağız

            string modelJson = System.Text.Json.JsonSerializer.Serialize(model);

            StringContent content = new StringContent(modelJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.PostAsync("/api/Categories/Ekle", content);

            if (responseMessage != null && responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // Burada kayit yapildi ve gerekli aksiyon sonrasi bir yere yönlendirme yapilabilri.

                TempData["RecordMessage"] = "Kayit yapilmiştir.";
                TempData["RecordStatus"] = true;

                return RedirectToAction(nameof(Index));
            }


            ViewData["RecordMessage"] = "Kayit yapilamamıştır.";
            ViewData["RecordStatus"] = false;

            return View(model);
        }

        // GET: CategoryController/Edit/5
        [BreadCrumbActionFilter(Title = "Kategoriler@Index|Kategori Düzenle")]
        public async Task<ActionResult> Edit(int id)
        {
            var kategori = await _httpClient.GetFromJsonAsync<CategoryViewModel>("https://localhost:7029/api/categories/Bul?id=" + id);

            return View(kategori);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryViewModel kategori)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(kategori);
                }

                kategori.AppUserId = Convert.ToInt32(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value); ;//Login olan User Id  => AspNetUser da ki ID  Identity Login Kısımını yapılması gerekiyor
                var responseMessage = await _httpClient.PutAsJsonAsync("https://localhost:7029/api/categories/guncelle?id=" + kategori.Id, kategori);
                if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("DbError", "Veritabanı guncelleme hatası");

                    return View(kategori);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GeneralException", ex.Message);
                ModelState.AddModelError("GeneralInnerException", ex.InnerException?.Message);
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var kategori = await _httpClient.GetFromJsonAsync<CategoryViewModel>("https://localhost:7029/api/categories/Bul?id=" + id);
            return View(kategori);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewModel kategori)
        {
            await _httpClient.DeleteAsync("https://localhost:7029/api/categories/sil?id=" + kategori.Id);
            return RedirectToAction("index");
        }
    }
}
