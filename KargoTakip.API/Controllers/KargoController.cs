using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KargoController : ControllerBase
    {
        private IKargoManager KargoManager;
        public KargoController(IKargoManager kargoManager)
        {
            KargoManager = kargoManager;
        }

        // GET: api/<AdresController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await KargoManager.Listele(x => x.AktifMi == true && x.SilindiMi == false, "TeslimAlanPersonel", "TeslimEdenPersonel", "GönderenMusteri", "AliciMusteri", "GönderenSube", "AliciSube", "Ucret");
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<KargoController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await KargoManager.Getir(x => x.ID == id, "TeslimAlanPersonel", "TeslimEdenPersonel", "GönderenMusteri", "AliciMusteri", "GönderenSube", "AliciSube", "Ucret");
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<KargoController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Kargo kargo)
        {
            if (string.IsNullOrEmpty(kargo.TakipNo))
                return BadRequest();
            await KargoManager.Ekle(kargo);
            return Ok(kargo);
        }

        // PUT api/<KargoController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Kargo kargo)
        {
            var ads = await KargoManager.GetirID(id);
            if (ads == null)
                return NotFound();
            else
            {
                await KargoManager.Guncelle(kargo);
                return Ok(ads);
            }

        }

        // DELETE api/<KargoController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var kargo = await KargoManager.GetirID(id);
            if (kargo == null)
                return NotFound();
            else
            {
                await KargoManager.Sil(id);
                return Ok();
            }
        }

        // GET api/<KargoController>/5
        [HttpGet("Ara")]
        public async Task<IActionResult> Ara(string takipNo)
        {
            var sonuc = await KargoManager.Getir(x => x.TakipNo == takipNo, "KargoDetaylari", "TeslimAlanPersonel");
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }
    }
}
