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
    public class SubeController : Controller
    {
        private string baseUrl = "https://localhost:7213/Sube";

        public SubeController()
        {
        }


        // GET: Admin/Sube
        [HttpGet("/Admin/Sube/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<SubeDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<SubeDto>());
            else
                return View(sonuc);
        }

        // GET: Admin/Sube/Details/5
        [HttpGet("/Admin/Sube/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<SubeDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }


        // GET: Admin/Sube/Create
        [HttpGet("/Admin/Sube/Create")]
        public async Task<IActionResult> Create()
        {

            string url = "https://localhost:7213/Adres";
            var adresListesi = await RestHelper.GetRequestAsync<List<AdresDto>>(url + "/Listele");
            ViewBag.Adres = new SelectList(adresListesi, "ID", "AdresAdi");

            return View();
        }
        // POST: Admin/Sube/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubeAdi,AdresId")] SubeDto sube)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<SubeDto, SubeDto>(baseUrl + "/Ekle", sube);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(sube);
        }


        [HttpGet("/Admin/Sube/Edit")]
        // GET: Sube/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<SubeDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
            {
                string url = "https://localhost:7213/Adres";
                var adresListesi = await RestHelper.GetRequestAsync<List<AdresDto>>(url + "/Listele");
                ViewBag.Adres = new SelectList(adresListesi, "ID", "AdresAdi");
                return View(sonuc);
            }
        }
        // POST: Sube/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubeAdi,AdresId")] SubeDto sube)
        {
            if (id != sube.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<SubeDto, SubeDto>(baseUrl + "/Guncelle/?id=" + id, sube, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(sube);
        }
    

    // GET: Admin/Sube/Delete/5
    [HttpGet("/Admin/Sube/Delete")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var sonuc = await RestHelper.GetRequestAsync<SubeDto>(baseUrl + "/Getir/?id=" + id);
        if (sonuc is null)
            return NotFound();
        else
            return View(sonuc);
    }

        // POST: Admin/Sube/Delete/5
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
