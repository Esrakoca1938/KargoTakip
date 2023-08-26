using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KargoTakip.WebUI.Models;
using RestSharp;

namespace KargoTakip.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MusteriController : Controller
    {
        private string baseUrl = "https://localhost:7213/Musteri";

        public MusteriController()
        {
        }
        // GET: Admin/Musteri
        [HttpGet("/Admin/Musteri/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<MusteriDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<MusteriDto>());
            else
                return View(sonuc);
        }
        // GET: Admin/Musteri/Details/5
        [HttpGet("/Admin/Musteri/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<MusteriDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // GET: Admin/Musteri/Create
        [HttpGet("/Admin/Musteri/Create")]
        public async Task<IActionResult> Create()
        {

            string url = "https://localhost:7213/Adres";
            var adresListesi = await RestHelper.GetRequestAsync<List<AdresDto>>(url + "/Listele");
            ViewBag.Adres = new SelectList(adresListesi, "ID", "Adres");

            return View();
        }

        // POST: Admin/Musteri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Soyadi,KimlikNo,Sifre,AdresId")] MusteriDto musteri)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<MusteriDto, MusteriDto>(baseUrl + "/Ekle", musteri);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        [HttpGet("/Admin/Musteri/Edit")]
        // GET: Musteri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<MusteriDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
            {
                string url = "https://localhost:7213/Adres";
                var adresListesi = await RestHelper.GetRequestAsync<List<AdresDto>>(url + "/Listele");
                ViewBag.Adres = new SelectList(adresListesi, "ID", "Adres");
                return View(sonuc);
            }
        }

        // POST: Admin/Musteri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,KimlikNo,Sifre,AdresId")] MusteriDto musteri)
        {
            if (id != musteri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<MusteriDto, MusteriDto>(baseUrl + "/Guncelle/?id=" + id, musteri, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(musteri);
        }

        // GET: Admin/Musteri/Delete/5
        [HttpGet("/Admin/Musteri/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<MusteriDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Admin/Musteri/Delete/5
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

