using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KargoTakip.WebUI.Models;
using RestSharp;
using KargoTakip.Core.Enum;

namespace KargoTakip.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KargoController : Controller
    {
        private string baseUrl = "https://localhost:7213/Kargo";

        public KargoController()
        {
        }


        // GET: Admin/Kargo
        [HttpGet("/Admin/Kargo/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<KargoDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<KargoDto>());
            else
                return View(sonuc);
        }

        // GET: Admin/Kargo/Details/5
        [HttpGet("/Admin/Kargo/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<KargoDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // GET: Admin/Kargo/Create
        [HttpGet("/Admin/Kargo/Create")]
        public async Task<IActionResult> Create()
        {

            string url = "https://localhost:7213";
            var musteriListesi = await RestHelper.GetRequestAsync<List<MusteriDto>>(url + "/Musteri/Listele");
            if (musteriListesi != null)
                ViewBag.Musteri = new SelectList(musteriListesi, "ID", "AdSoyad");

            var subeListesi = await RestHelper.GetRequestAsync<List<SubeDto>>(url + "/Sube/Listele");
            ViewBag.Sube = new SelectList(subeListesi, "ID", "SubeAdi");

            var personelListesi = await RestHelper.GetRequestAsync<List<PersonelDto>>(url + "/Personel/Listele");
            ViewBag.Personel = new SelectList(personelListesi, "ID", "AdSoyad");

            var ucretListesi = await RestHelper.GetRequestAsync<List<UcretDto>>(url + "/Ucret/Listele");
            ViewBag.Ucret = new SelectList(ucretListesi, "ID", "BuyuklukTutar");

            var odemeTuruListesi = Enum.GetValues(typeof(OdemeTuru)).Cast<OdemeTuru>().Select(x => new {ID=x,Adi=x.ToString()});
            var durumListesi = Enum.GetValues(typeof(KargoDurum)).Cast<KargoDurum>().Select(x => new {ID=x,Adi=x.ToString()});

			ViewBag.OdemeTuru = new SelectList(odemeTuruListesi, "ID", "Adi");
			ViewBag.Durum = new SelectList(durumListesi, "ID", "Adi");
            
            return View();
        }
        // POST: Admin/Kargo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TakipNo,GonderenMusteriId,AliciMusteriId,GonderenSubeId,AliciSubeId,TeslimAlanPersonelId,TeslimEdenPersonelId,UcretId,OdemeTuru,TahminiTeslimTarihi,TeslimTarihi,Durum")] KargoDto kargo)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KargoDto, KargoDto>(baseUrl + "/Ekle", kargo);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(kargo);
        }
        // GET: Admin/Kargo/Edit/5
        [HttpGet("/Admin/Kargo/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KargoDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
            {
                string url = "https://localhost:7213";
                var musteriListesi = await RestHelper.GetRequestAsync<List<MusteriDto>>(url + "/Musteri/Listele");
                ViewBag.Musteri = new SelectList(musteriListesi, "ID", "AdSoyad");

                var subeListesi = await RestHelper.GetRequestAsync<List<SubeDto>>(url + "/Sube/Listele");
                ViewBag.Sube = new SelectList(subeListesi, "ID", "SubeAdi");

                var personelListesi = await RestHelper.GetRequestAsync<List<PersonelDto>>(url + "/Personel/Listele");
                ViewBag.Personel = new SelectList(personelListesi, "ID", "AdSoyad");

                var ucretListesi = await RestHelper.GetRequestAsync<List<UcretDto>>(url + "/Ucret/Listele");
                ViewBag.Ucret = new SelectList(ucretListesi, "ID", "BuyuklukTutar");

				var odemeTuruListesi = Enum.GetValues(typeof(OdemeTuru)).Cast<OdemeTuru>().Select(x => new { ID = x, Adi = x.ToString() });
				var durumListesi = Enum.GetValues(typeof(KargoDurum)).Cast<KargoDurum>().Select(x => new { ID = x, Adi = x.ToString() });

				ViewBag.OdemeTuru = new SelectList(odemeTuruListesi, "ID", "Adi");
				ViewBag.Durum = new SelectList(durumListesi, "ID", "Adi");

				return View(sonuc);
            }
        }

        // POST: Admin/Kargo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TakipNo,GonderenMusteriId,AliciMusteriId,GonderenSubeId,AliciSubeId,TeslimAlanPersonelId,TeslimEdenPersonelId,UcretId,OdemeTuru,TahminiTeslimTarihi,TeslimTarihi,Durum")] KargoDto kargo)
        {
            if (id != kargo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KargoDto, KargoDto>(baseUrl + "/Guncelle/?id=" + id, kargo, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(kargo);
        }


        // GET: Admin/Kargo/Delete/5
        [HttpGet("/Admin/Kargo/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KargoDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Admin/Kargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = baseUrl + "/Sil/?id=" + id;
            var client = new RestClient();
            var request = new RestRequest(url, Method.Delete);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var resp = await client.ExecuteAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return BadRequest();
        }

    }
}
