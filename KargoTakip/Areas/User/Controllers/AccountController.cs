using KargoTakip.WebUI.Helper.SessionHelper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.AspNetCore.Http;
using KargoTakip.Core.DTO;
using System.Security.Cryptography;
using System.Text;
using KargoTakip.WebUI.Models;

namespace KargoTakip.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor HttpContextAccessor;

        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        [HttpGet("/User/Account/UserLogin")]
        public IActionResult Index()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpGet("/User/Account/Logout")]
        public IActionResult Logout()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return Redirect("/User/Account/UserLogin");
        }

        [HttpPost("/User/Account/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(LoginDto loginDTO)
        {
            var url = "https://localhost:7213/Account/Login";
            var data = Encoding.ASCII.GetBytes(loginDTO.Sifre);
            var hashed = MD5.HashData(data);
            loginDTO.Sifre = Encoding.ASCII.GetString(hashed);
            var res = await RestHelper.PostRequestAsync<LoginDto, ApiSonuc<LoginDto>>(url, loginDTO);

            //var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(restResponse.Content);

            if (res == null)
            {                
                ViewBag.LoginError = "Kullanıcı Adı Veya Şifre Yanlış";
                ViewData["LoginError"] = "Kullanıcı Adı Veya Şifre Yanlış";
                return View("Index");
            }
            SessionManager.LoggedUser = res.Data;

            return Redirect("/User/Home/Index");

        }

        [HttpGet("/User/Account/Register")]
        public IActionResult Register()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpPost("/User/Account/Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MusteriDto musteriDto)
        {
            var url = "https://localhost:7213/Account/Register";
            var data = Encoding.ASCII.GetBytes(musteriDto.Sifre);
            var hashed = MD5.HashData(data);
            musteriDto.Sifre = Encoding.ASCII.GetString(hashed);
            var res = await RestHelper.PostRequestAsync<MusteriDto, ApiSonuc<LoginDto>>(url, musteriDto);

            //var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(restResponse.Content);
            if (res == null)
            {
                ViewBag.RegisterError = "Kullanıcı oluşturulamadı";
                ViewData["RegisterError"] = "Kullanıcı oluşturulamadı";
                return View("Register");
            }

            SessionManager.LoggedUser = res.Data;
            return Redirect("/User/Home/Index");

        }

        [HttpGet("/User/Account/Search")]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost("/User/Account/SearchResult")]
        public async Task<IActionResult> SearchResult(KargoTakipDto kargoTakip)
        {
            var url = "https://localhost:7213/Kargo/Ara/?takipNo=" + kargoTakip.TakipNo;
            var res = await RestHelper.GetRequestAsync<KargoDto>(url);

			return View(res);
		}
    }
}
