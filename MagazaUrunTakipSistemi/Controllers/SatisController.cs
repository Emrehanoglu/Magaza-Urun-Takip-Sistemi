using MagazaUrunTakipSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class SatisController : Controller
    {
		DbMagazaUrunTakipEntities db = new DbMagazaUrunTakipEntities();
		public ActionResult Index()
        {
			var satislar = db.TblSatis.ToList();
			return View(satislar);
        }
		[HttpGet]
		public ActionResult YeniSatis()
		{
			List<SelectListItem> urun = (from x in db.TblUrunler
										 select new SelectListItem
										 {
											 Text = x.Ad,
											 Value = x.Id.ToString()
										 }).ToList();
			ViewBag.urunler = urun;
			List<SelectListItem> personel = (from x in db.TblPersonel
										 select new SelectListItem
										 {
											 Text = x.Ad,
											 Value = x.Id.ToString()
										 }).ToList();
			ViewBag.personeller = personel;
			List<SelectListItem> musteri = (from x in db.TblMusteri
										 select new SelectListItem
										 {
											 Text = x.Ad,
											 Value = x.Id.ToString()
										 }).ToList();
			ViewBag.musteriler = musteri;
			return View();
		}
		[HttpPost]
		public ActionResult YeniSatis(TblMusteri t)
		{
			if (!ModelState.IsValid)
			{
				return View("MusteriEkle");
			}
			db.TblMusteri.Add(t);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}