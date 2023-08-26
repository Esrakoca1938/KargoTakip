﻿using System;
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
    public class PersonelController : Controller
    {
        private string baseUrl = "https://localhost:7213/Personel";

        public PersonelController()
        {
        }

        // GET: Personel

        [HttpGet("/Admin/Personel/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<PersonelDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<PersonelDto>());
            else
                return View(sonuc);
        }

        //GET: Personel/Details/5

        [HttpGet("/Admin/Personel/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sonuc = await RestHelper.GetRequestAsync<PersonelDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        [HttpGet("/Admin/Personel/Create")]
        // GET: Personel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Soyadi,KimlikNo,Cinsiyet,Email,Pozisyon,Sifre")] PersonelDto personel)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<PersonelDto, PersonelDto>(baseUrl + "/Ekle", personel);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(personel);
        }

        [HttpGet("/Admin/Personel/Edit")]
        // GET: Personel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<PersonelDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,Pozisyon,Cinsiyet,Email,KimlikNo,Sifre,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] PersonelDto personel)
        {
            if (id != personel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<PersonelDto, PersonelDto>(baseUrl + "/Guncelle/?id=" + id, personel, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(personel);
        }

        // GET: Personel/Delete/5

        [HttpGet("/Admin/Personel/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<PersonelDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Personel/Delete/5
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
