using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Web;
using ViewModels;
using WepAPI.Models;
using Newtonsoft.Json;

namespace ETicaretMVC.Controllers
{
    public class AccountController : Controller
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public AccountController(IConfiguration configuration, HttpClient httpClient )
        {
            //_httpClient = new HttpClient();
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(configuration.GetSection("Api:Base").Value); //Api url

            _configuration = configuration;
        }

        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string modelJson = System.Text.Json.JsonSerializer.Serialize(model);

            StringContent content = new StringContent(modelJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.PostAsync(_configuration["Api:Register:EndPoints"], content);

            if (responseMessage != null && responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                TempData["RegisterInfo"] = $"Kayıt işlemi tamamlandı. {model.Email} adresinize doğrulama linki gönderildi.";
                return RedirectToAction("Index", "Home");
            }

            // TODO register işleminde ki tüm hatalar yaklanmalı ve geri dönüş o şekilde yapılmalıdır. Örnek Email daha önce kullanılmıştır, Şifre uygun değildir.

            return BadRequest();
        }

        public async Task<IActionResult> ConfirmEmail(string userMail, string token)
        {
            token = HttpUtility.UrlEncode(token);

            string endPoints = _configuration["Api:ConfirmEmail:EndPoints"] + "?userMail=" + userMail + "&token=" + token;

            HttpResponseMessage responseMessage = await _httpClient.GetAsync(endPoints);

            if (responseMessage != null && responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                return RedirectToAction(nameof(Login));

            ViewBag.Error = $"{userMail} adresiniz için doğrulama yapılamamıştır.";

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            SignInViewModel signInViewModel = new SignInViewModel();
            signInViewModel.Email = email;
            signInViewModel.Password = password;

            string modelJson = System.Text.Json.JsonSerializer.Serialize(signInViewModel);

            StringContent content = new StringContent(modelJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.PostAsync(_configuration["Api:Login:EndPoints"], content);

            if (responseMessage != null && responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Burada kayıt yapıldı ve gerekli aksiyon sonrası bir yere yönlendirme yapılabilri.

                string token = responseMessage.Content.ReadAsStringAsync().Result;

                //Token Çözülecek

                string[] tokenInfo = token.Split('.');

                string payloadBase64 = tokenInfo[1];
                string payload = Encoding.UTF8.GetString(Base64UrlDecode(payloadBase64));


                Dictionary<string, string> model = JsonConvert.DeserializeObject<Dictionary<string, string>>(payload);


                List<Claim> claims = new List<Claim>();

                foreach (KeyValuePair<string, string> item in model)
                {
                    Claim claim = new Claim(item.Key, item.Value);
                    claims.Add(claim);
                }


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //HttpContext.Session.SetString("BasicAuth", responseViewModel.BasicAuth);
                HttpContext.Session.SetString("TokenAuth", token);

                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }

        private byte[] Base64UrlDecode(string arg)
        {
            string s = arg;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: s += "=="; break; // Two pad chars
                case 3: s += "="; break; // One pad char
                default:
                    throw new System.Exception(
                  "Illegal base64url string!");
            }
            return Convert.FromBase64String(s); // Standard base64 decoder
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
