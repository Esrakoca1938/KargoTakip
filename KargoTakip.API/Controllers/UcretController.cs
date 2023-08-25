using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UcretController : ControllerBase
    {
        private IUcretManager UcretManager;
        public UcretController(IUcretManager ucretManager)
        {
            UcretManager = ucretManager;
        }

        // GET: api/<PersonelController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await UcretManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<PersonelController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await UcretManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<PersonelController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Ucret ucret)
        {
            if (string.IsNullOrEmpty(ucret.Buyukluk))
                return BadRequest();
            await UcretManager.Ekle(ucret);
            return Ok(ucret);
        }

        // PUT api/<PersonelController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Ucret ucret)
        {
            var pers = await UcretManager.GetirID(id);
            if (pers == null)
                return NotFound();
            else
            {
                await UcretManager.Guncelle(ucret);
                return Ok(pers);
            }

        }

        // DELETE api/<PersonelController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var ucret = await UcretManager.GetirID(id);
            if (ucret == null)
                return NotFound();
            else
            {
                await UcretManager.Sil(id);
                return Ok();
            }
        }
    }
}
