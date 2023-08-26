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
    public class UcretController : Controller
    {
        private string baseUrl = "https://localhost:7213/Ucret";

        public UcretController()
        {
        }


        // GET: Admin/Ucret
        [HttpGet("/Admin/Ucret/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<UcretDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<UcretDto>());
            else
                return View(sonuc);
        }

        // GET: Admin/Ucret/Details/5
        [HttpGet("/Admin/Ucret/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<UcretDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // GET: Admin/Ucret/Create
        [HttpGet("/Admin/Ucret/Create")]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Admin/Ucret/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Buyukluk,Tutar,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] UcretDto ucret)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<UcretDto, UcretDto>(baseUrl + "/Ekle", ucret);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(ucret);
        }


        [HttpGet("/Admin/Ucret/Edit")]
        // GET: Ucret/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<UcretDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // POST: Admin/Ucret/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Buyukluk,Tutar,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] UcretDto ucret)
        {
            if (id != ucret.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<UcretDto, UcretDto>(baseUrl + "/Guncelle/?id=" + id, ucret, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(ucret);
        }

        // GET: Admin/Ucret/Delete/5
        [HttpGet("/Admin/Ucret/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<UcretDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Admin/Ucret/Delete/5
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
