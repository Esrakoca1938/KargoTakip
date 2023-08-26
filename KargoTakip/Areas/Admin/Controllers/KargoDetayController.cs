using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KargoTakip.WebUI.Models;
using RestSharp;
using System.Security.Policy;


namespace KargoTakip.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KargoDetayController : Controller
    {
        private string baseUrl = "https://localhost:7213/KargoDetay";

        public KargoDetayController()
        {
        }


        // GET: Admin/KargoDetay
        [HttpGet("/Admin/KargoDetay/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<KargoDetayDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<KargoDetayDto>());
            else
                return View(sonuc);
        }

        // GET: Admin/KargoDetay/Details/5
        [HttpGet("/Admin/KargoDetay/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<KargoDetayDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }


        // GET: Admin/KargoDetay/Create
        [HttpGet("/Admin/KargoDetay/Create")]
        public async Task<IActionResult> Create()
        {

            string url = "https://localhost:7213";
            var kargoListesi = await RestHelper.GetRequestAsync<List<KargoDto>>(url + "/Kargo/Listele");
            ViewBag.Kargo = new SelectList(kargoListesi, "ID", "Kargo");

            var subeListesi = await RestHelper.GetRequestAsync<List<SubeDto>>(url + "/Sube/Listele");
            ViewBag.Sube = new SelectList(subeListesi, "ID", "Sube");

            var islemturuListesi = await RestHelper.GetRequestAsync<List<IslemTuruDto>>(url + "/IslemTuru/Listele");
            ViewBag.IslemTuru = new SelectList(islemturuListesi, "ID", "IslemTuru");

            return View();
        }


        // POST: Admin/KargoDetay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KargoId,SubeId,IslemTuruId")] KargoDetayDto kargoDetay)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KargoDetayDto, KargoDetayDto>(baseUrl + "/Ekle", kargoDetay);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(kargoDetay);
        }

        // GET: Admin/KargoDetay/Edit/5
        [HttpGet("/Admin/KargoDetay/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KargoDetayDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
            {
                string url = "https://localhost:7213";
                var kargoListesi = await RestHelper.GetRequestAsync<List<KargoDto>>(url + "/Kargo/Listele");
                ViewBag.Kargo = new SelectList(kargoListesi, "ID", "Kargo");

                var subeListesi = await RestHelper.GetRequestAsync<List<SubeDto>>(url + "/Sube/Listele");
                ViewBag.Sube = new SelectList(subeListesi, "ID", "Sube");

                var islemturuListesi = await RestHelper.GetRequestAsync<List<IslemTuruDto>>(url + "/IslemTuru/Listele");
                ViewBag.IslemTuru = new SelectList(islemturuListesi, "ID", "IslemTuru");

                return View(sonuc);
            }
        }

        // POST: Admin/KargoDetay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KargoId,SubeId,IslemTuruId")] KargoDetayDto kargoDetay)
        {
            if (id != kargoDetay.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KargoDetayDto, KargoDetayDto>(baseUrl + "/Guncelle/?id=" + id, kargoDetay, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(kargoDetay);
        }

        // GET: Admin/KargoDetay/Delete/5
        [HttpGet("/Admin/KargoDetay/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KargoDetayDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }


        // POST: Admin/KargoDetay/Delete/5
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
