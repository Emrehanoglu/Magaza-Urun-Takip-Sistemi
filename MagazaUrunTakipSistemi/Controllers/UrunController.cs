using MagazaUrunTakipSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
	[Authorize]
	public class UrunController : Controller
    {
		DbMagazaUrunTakipEntities db = new DbMagazaUrunTakipEntities();
		public ActionResult Index()
        {
			var urunler = db.TblUrunler.Where(x=>x.Durum == true).ToList();
            return View(urunler);
        }
		[HttpGet]
		public ActionResult UrunEkle()
		{
			List<SelectListItem> kategoriler = (from x in db.TblKategori
													   select new SelectListItem
													   {
														   Text = x.Ad,
														   Value = x.Id.ToString()
													   }).ToList();
			ViewBag.ktgr = kategoriler;
			return View();
		}
		[HttpPost]
		public ActionResult UrunEkle(TblUrunler t)
		{
			t.Durum = true;
			db.TblUrunler.Add(t);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UrunSil(int id)
		{
			var k = db.TblUrunler.Find(id);
			k.Durum = false;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UrunEdit(int id)
		{
			List<SelectListItem> kategoriler = (from x in db.TblKategori
												select new SelectListItem
												{
													Text = x.Ad,
													Value = x.Id.ToString()
												}).ToList();
			ViewBag.ktgr = kategoriler;
			var k = db.TblUrunler.Find(id);
			return View(k);
		}
		[HttpPost]
		public ActionResult UrunEdit(TblUrunler t)
		{
			var k = db.TblUrunler.Find(t.Id);
			k.Ad = t.Ad;
			k.Marka = t.Marka;
			k.Stok = t.Stok;
			k.AlisFiyat = t.AlisFiyat;
			k.SatisFiyat = t.SatisFiyat;
			k.Kategori = t.Kategori;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}