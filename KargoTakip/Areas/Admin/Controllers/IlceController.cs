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
	public class IlceController : Controller
	{
		private string baseUrl = "https://localhost:7213/Ilce";

		public IlceController()
		{
		}

		// GET: Admin/Ilce
		[HttpGet("/Admin/Ilce/Index")]
		public async Task<IActionResult> Index()
		{
			var sonuc = await RestHelper.GetRequestAsync<List<IlceDto>>(baseUrl + "/Listele");
			if (sonuc is null)
				return View(new List<IlceDto>());
			else
				return View(sonuc);
		}

		// GET: Admin/Ilce/Details/5
		[HttpGet("/Admin/Ilce/Details")]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}


			var sonuc = await RestHelper.GetRequestAsync<IlceDto>(baseUrl + "/Getir/?id=" + id);
			if (sonuc is null)
				return NotFound();
			else
				return View(sonuc);

		}

		// GET: Admin/Ilce/Create
		[HttpGet("/Admin/Ilce/Create")]
		public async Task<IActionResult> Create()
		{

			string url = "https://localhost:7213/Sehir";
			var sehirListesi = await RestHelper.GetRequestAsync<List<SehirDto>>(url + "/Listele");
			ViewBag.Sehir = new SelectList(sehirListesi, "ID", "SehirAdi");

			return View();
		}

		// POST: Admin/Ilce/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IlceAdi,SehirId")] IlceDto ilce)
		{
			if (ModelState.IsValid)
			{
				var sonuc = await RestHelper.PostRequestAsync<IlceDto, IlceDto>(baseUrl + "/Ekle", ilce);
				if (sonuc is null)
					return BadRequest();
				else
					return RedirectToAction(nameof(Index));
			}
			return View(ilce);
		}

		[HttpGet("/Admin/Ilce/Edit")]

		// GET: Admin/Ilce/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var sonuc = await RestHelper.GetRequestAsync<IlceDto>(baseUrl + "/Getir/?id=" + id);
			if (sonuc is null)
				return NotFound();
			else
				return View(sonuc);

		}

		// POST: Admin/Ilce/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IlceAdi,SehirId")] IlceDto ilce)
		{
			if (id != ilce.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var sonuc = await RestHelper.PostRequestAsync<IlceDto, IlceDto>(baseUrl + "/Guncelle/?id=" + id, ilce, Method.Put);
				if (sonuc is null)
					return BadRequest();
				else
					return RedirectToAction(nameof(Index));

			}
			return View(ilce);
		}

		// GET: Admin/Ilce/Delete/5
		[HttpGet("/Admin/Ilce/Delete")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var sonuc = await RestHelper.GetRequestAsync<IlceDto>(baseUrl + "/Getir/?id=" + id);
			if (sonuc is null)
				return NotFound();
			else
				return View(sonuc);
		}


		// POST: Admin/Ilce/Delete/5
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
