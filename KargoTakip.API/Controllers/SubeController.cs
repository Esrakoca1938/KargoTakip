using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubeController : ControllerBase
    {
        private ISubeManager SubeManager;
        public SubeController(ISubeManager subeManager)
        {
            SubeManager = subeManager;
        }

        // GET: api/<PersonelController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await SubeManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<PersonelController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await SubeManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<PersonelController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Sube sube)
        {
            if (string.IsNullOrEmpty(sube.SubeAdi))
                return BadRequest();
            await SubeManager.Ekle(sube);
            return Ok(sube);
        }

        // PUT api/<PersonelController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Sube sube)
        {
            var ads = await SubeManager.GetirID(id);
            if (ads == null)
                return NotFound();
            else
            {
                await SubeManager.Guncelle(sube);
                return Ok(ads);
            }

        }

        // DELETE api/<PersonelController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var sube = await SubeManager.GetirID(id);
            if (sube == null)
                return NotFound();
            else
            {
                await SubeManager.Sil(id);
                return Ok();
            }
        }
    }
}
