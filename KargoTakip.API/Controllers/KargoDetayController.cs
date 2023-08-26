using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KargoDetayController : ControllerBase
    {
        private IKargoDetayManager KargoDetayManager;
        public KargoDetayController(IKargoDetayManager kargodetayManager)
        {
            KargoDetayManager = kargodetayManager;
        }

        // GET: api/<PersonelController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await KargoDetayManager.Listele(x => x.AktifMi == true && x.SilindiMi == false, "Sube", "IslemTuru", "Kargo");
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<PersonelController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await KargoDetayManager.Getir(x => x.ID == id, "Sube", "IslemTuru", "Kargo");
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<PersonelController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] KargoDetay kargodetay)
        {
          
            await KargoDetayManager.Ekle(kargodetay);
            return Ok(kargodetay);
        }

        // PUT api/<PersonelController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] KargoDetay kargodetay)
        {
            var pers = await KargoDetayManager.GetirID(id);
            if (pers == null)
                return NotFound();
            else
            {
                await KargoDetayManager.Guncelle(kargodetay);
                return Ok(pers);
            }

        }

        // DELETE api/<PersonelController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var kargodetay = await KargoDetayManager.GetirID(id);
            if (kargodetay == null)
                return NotFound();
            else
            {
                await KargoDetayManager.Sil(id);
                return Ok();
            }
        }
    }
}
