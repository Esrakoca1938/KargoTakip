using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        private ISehirManager SehirManager;
        public SehirController(ISehirManager sehirManager)
        {
            SehirManager = sehirManager;
        }

        // GET: api/<PersonelController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await SehirManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<PersonelController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await SehirManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<PersonelController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Sehir sehir)
        {
            if (string.IsNullOrEmpty(sehir.SehirAdi))
                return BadRequest();
            await SehirManager.Ekle(sehir);
            return Ok(sehir);
        }

        // PUT api/<PersonelController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Sehir sehir)
        {
            var pers = await SehirManager.GetirID(id);
            if (pers == null)
                return NotFound();
            else
            {
                await SehirManager.Guncelle(sehir);
                return Ok(pers);
            }

        }

        // DELETE api/<PersonelController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var sehir = await SehirManager.GetirID(id);
            if (sehir == null)
                return NotFound();
            else
            {
                await SehirManager.Sil(id);
                return Ok();
            }
        }
    }
}
