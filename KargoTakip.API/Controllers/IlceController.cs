using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IlceController : ControllerBase
    {
        private IIlceManager IlceManager;
        public IlceController(IIlceManager ilceManager)
        {
            IlceManager = ilceManager;
        }

        // GET: api/<IlceController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await IlceManager.Listele(x => x.AktifMi == true && x.SilindiMi == false, "Sehir");
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<IlceController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await IlceManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<IlceController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Ilce ilce)
        {
            if (string.IsNullOrEmpty(ilce.IlceAdi))
                return BadRequest();
            await IlceManager.Ekle(ilce);
            return Ok(ilce);
        }

        // PUT api/<IlceController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Ilce ilce)
        {
            var pers = await IlceManager.GetirID(id);
            if (pers == null)
                return NotFound();
            else
            {
                await IlceManager.Guncelle(ilce);
                return Ok(pers);
            }

        }

        // DELETE api/<IlceController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var Ilce = await IlceManager.GetirID(id);
            if (Ilce == null)
                return NotFound();
            else
            {
                await IlceManager.Sil(id);
                return Ok();
            }
        }
    }
}
