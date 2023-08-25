using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IslemTuruController : ControllerBase
    {
        private IIslemTuruManager IslemTuruManager;
        public IslemTuruController(IIslemTuruManager islemturuManager)
        {
            IslemTuruManager = islemturuManager;
        }

        // GET: api/<IslemTuruController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await IslemTuruManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<IslemTuruController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await IslemTuruManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<PersonelController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] IslemTuru islemturu)
        {
            if (string.IsNullOrEmpty(islemturu.IslemTuruAdi))
                return BadRequest();
            await IslemTuruManager.Ekle(islemturu);
            return Ok(islemturu);
        }
        // PUT api/<PersonelController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] IslemTuru islemturu)
        {
            var ads = await IslemTuruManager.GetirID(id);
            if (ads == null)
                return NotFound();
            else
            {
                await IslemTuruManager.Guncelle(islemturu);
                return Ok(ads);
            }

        }

        // DELETE api/<PersonelController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var islemturu = await IslemTuruManager.GetirID(id);
            if (islemturu == null)
                return NotFound();
            else
            {
                await IslemTuruManager.Sil(id);
                return Ok();
            }
        }
    }
}
