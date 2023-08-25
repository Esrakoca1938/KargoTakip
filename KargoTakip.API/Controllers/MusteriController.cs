using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KargoTakip.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private IMusteriManager MusteriManager;
        public MusteriController(MusteriManager musteriManager)
        {
            MusteriManager = musteriManager;
        }

        // GET: api/<PersonelController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await MusteriManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<PersonelController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await MusteriManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<PersonelController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Musteri musteri)
        {
            if (string.IsNullOrEmpty(musteri.Adi) || string.IsNullOrEmpty(musteri.Soyadi))
                return BadRequest();
            await MusteriManager.Ekle(musteri);
            return Ok(musteri);
        }

        // PUT api/<PersonelController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Musteri musteri)
        {
            var mst = await MusteriManager.GetirID(id);
            if (mst == null)
                return NotFound();
            else
            {
                await MusteriManager.Guncelle(musteri);
                return Ok(mst);
            }

        }

        // DELETE api/<PersonelController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var musteri = await MusteriManager.GetirID(id);
            if (musteri== null)
                return NotFound();
            else
            {
                await MusteriManager.Sil(id);
                return Ok();
            }
        }
    }
}
