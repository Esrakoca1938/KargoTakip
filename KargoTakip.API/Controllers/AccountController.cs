using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Core.DTO;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager AccountManager;
        private readonly IConfiguration Configuration;

        public AccountController(IAccountManager accountManager, IConfiguration configuration)
        {
            AccountManager = accountManager;
            Configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (string.IsNullOrEmpty(login.KimlikNo) || string.IsNullOrEmpty(login.Sifre))
                return BadRequest();
            var user = await AccountManager.KullaniciGetir(login);
            if (user == null)
            {
                return NotFound(ApiSonuc<LoginDto>.AuthenticationError());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();

                claims.Add(new Claim("KimlikNo", user.KimlikNo));
                claims.Add(new Claim("ID", user.ID.ToString()));

                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(30),
                    claims: claims,
                    issuer: "http://kargotakip.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                user.Token = token;

                return Ok(ApiSonuc<LoginDto>.SuccessWithData(user));

            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Musteri musteri)
        {
            if (string.IsNullOrEmpty(musteri.KimlikNo) || string.IsNullOrEmpty(musteri.Sifre) || string.IsNullOrEmpty(musteri.Adi) || string.IsNullOrEmpty(musteri.Soyadi))
                return BadRequest();
            var user = await AccountManager.MusteriGetir(musteri);
            if (user != null)
            {
                return NotFound(ApiSonuc<LoginDto>.RegistraionError());
            }
            else
            {
                user = await AccountManager.MusteriEkle(musteri);
                var key = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();

                claims.Add(new Claim("KimlikNo", user.KimlikNo));
                claims.Add(new Claim("ID", user.ID.ToString()));
                    
                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(30),
                    claims: claims,
                    issuer: "http://kargotakip.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                user.Token = token;

                return Ok(ApiSonuc<LoginDto>.SuccessWithData(user));

            }

        }
    }
}
