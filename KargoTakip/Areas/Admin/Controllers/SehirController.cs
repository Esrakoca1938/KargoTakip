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
    public class SehirController : Controller
    {
        private string baseUrl = "https://localhost:7213/Sehir";

        public SehirController()
        {
        }


        // GET: Admin/Sehir
        [HttpGet("/Admin/Sehir/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<SehirDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<SehirDto>());
            else
                return View(sonuc);
        }
        // GET: Admin/Sehir/Details/5

        [HttpGet("/Admin/Sehir/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<SehirDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

            [HttpGet("/Admin/Sehir/Create")]
            // GET: Sehir/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST:Sehir/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("SehirAdi")] SehirDto sehir)
            {
                if (ModelState.IsValid)
                {
                    var sonuc = await RestHelper.PostRequestAsync<SehirDto, SehirDto>(baseUrl + "/Ekle", sehir);
                    if (sonuc is null)
                        return BadRequest();
                    else
                        return RedirectToAction(nameof(Index));
                }
                return View(sehir);
            }

        [HttpGet("/Admin/Sehir/Edit")]
        // GET: Sehir/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<SehirDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // POST: Sehir/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SehirAdi")] SehirDto sehir)
        {
            if (id != sehir.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<SehirDto, SehirDto>(baseUrl + "/Guncelle/?id=" + id, sehir, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(sehir);
        }


        // GET: Admin/Sehir/Delete/5
        [HttpGet("/Admin/Sehir/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<SehirDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Admin/Sehir/Delete/5
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
