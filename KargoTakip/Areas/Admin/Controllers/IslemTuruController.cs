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
    public class IslemTuruController : Controller
    {
        private string baseUrl = "https://localhost:7213/IslemTuru";

        public IslemTuruController()
        {
        }

        // GET: Admin/IslemTuru
        [HttpGet("/Admin/IslemTuru/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<IslemTuruDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<IslemTuruDto>());
            else
                return View(sonuc);
        }

        // GET: Admin/IslemTuru/Details/5
        [HttpGet("/Admin/IslemTuru/Details")]
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }


                var sonuc = await RestHelper.GetRequestAsync<IslemTuruDto>(baseUrl + "/Getir/?id=" + id);
                if (sonuc is null)
                    return NotFound();
                else
                    return View(sonuc);

            }
            // GET: Admin/IslemTuru/Create
           [HttpGet("/Admin/IslemTuru/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/IslemTuru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IslemTuruAdi,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] IslemTuruDto islemTuru)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<IslemTuruDto, IslemTuruDto>(baseUrl + "/Ekle", islemTuru);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(islemTuru);
        }

        [HttpGet("/Admin/IslemTuru/Edit")]
        // GET: Admin/IslemTuru/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<IslemTuruDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // POST: Admin/IslemTuru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IslemTuruAdi,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] IslemTuruDto islemTuru)
        {
            if (id != islemTuru.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<IslemTuruDto, IslemTuruDto>(baseUrl + "/Guncelle/?id=" + id, islemTuru, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(islemTuru);
        }

        // GET: Admin/IslemTuru/Delete/5
        [HttpGet("/Admin/IslemTuru/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<IslemTuruDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }


        // POST: Admin/IslemTuru/Delete/5
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
