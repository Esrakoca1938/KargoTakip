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
    public class AdresController : Controller
    {
        private string baseUrl = "https://localhost:7213/Adres";

        public AdresController()
        {

        }
        // GET: Admin/Adres
        [HttpGet("/Admin/Adres/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<AdresDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<AdresDto>());
            else
                return View(sonuc);
        }


        // GET: Admin/Adres/Details/5
        [HttpGet("/Admin/Adres/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<AdresDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);


        }

        // GET: Admin/Adres/Create
        [HttpGet("/Admin/Adres/Create")]
        public async Task<IActionResult> Create()
        {

            string url = "https://localhost:7213";
            var sehirListesi = await RestHelper.GetRequestAsync<List<SehirDto>>(url + "/Sehir/Listele");
            ViewBag.Sehir = new SelectList(sehirListesi, "ID", "SehirAdi");

            var ilceListesi = await RestHelper.GetRequestAsync<List<IlceDto>>(url + "/Ilce/Listele");
            ViewBag.Ilce = new SelectList(ilceListesi, "ID", "IlceAdi");

            return View();
        }

        // POST: Admin/Adres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdresAdi,SehirId,IlceId,Detay,PostaKodu,Telefon,Email")] AdresDto adres)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<AdresDto, AdresDto>(baseUrl + "/Ekle", adres);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(adres);
        }

        [HttpGet("/Admin/Adres/Edit")]
        // GET: Admin/Adres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<AdresDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
            {
                string url = "https://localhost:7213";
                var sehirListesi = await RestHelper.GetRequestAsync<List<SehirDto>>(url + "/Sehir/Listele");
                ViewBag.Sehir = new SelectList(sehirListesi, "ID", "SehirAdi");

                var ilceListesi = await RestHelper.GetRequestAsync<List<IlceDto>>(url + "/Ilce/Listele");
                ViewBag.Ilce = new SelectList(ilceListesi, "ID", "IlceAdi");

                return View(sonuc);
            }
        }

        // POST: Admin/Adres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdresAdi,SehirId,IlceId,Detay,PostaKodu,Telefon,Email")] AdresDto adres)
        {
            if (id != adres.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<AdresDto, AdresDto>(baseUrl + "/Guncelle/?id=" + id, adres, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(adres);
        }

        // GET: Admin/Adres/Delete/5
        [HttpGet("/Admin/Adres/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<AdresDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Admin/Adres/Delete/5
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

