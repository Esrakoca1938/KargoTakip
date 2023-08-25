using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private IAdresManager AdresManager;
        public AdresController(IAdresManager adresManager)
        {
            AdresManager = adresManager;
        }

        // GET: api/<AdresController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await AdresManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<AdresController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await AdresManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<AdresController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Adres adres)
        {
            if (string.IsNullOrEmpty(adres.AdresAdi))
                return BadRequest();
            await AdresManager.Ekle(adres);
            return Ok(adres);
        }

        // PUT api/<AdresController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Adres adres)
        {
            var ads = await AdresManager.GetirID(id);
            if (ads == null)
                return NotFound();
            else
            {
                await AdresManager.Guncelle(adres);
                return Ok(ads);
            }

        }

        // DELETE api/<AdresController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var adres = await AdresManager.GetirID(id);
            if (adres == null)
                return NotFound();
            else
            {
                await AdresManager.Sil(id);
                return Ok();
            }
        }
    }
}
