using MagazaUrunTakipSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
	[Authorize]
    public class KategoriController : Controller
    {
		DbMagazaUrunTakipEntities db = new DbMagazaUrunTakipEntities();
        public ActionResult Index()
        {
			var kategoriler = db.TblKategori.ToList();
            return View(kategoriler);
        }
		[HttpGet]
		public ActionResult KategoriEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult KategoriEkle(TblKategori t)
		{
			db.TblKategori.Add(t);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult KategoriSil(int id)
		{
			var k = db.TblKategori.Find(id);
			db.TblKategori.Remove(k);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult KategoriEdit(int id)
		{
			var k = db.TblKategori.Find(id);
			return View(k);
		}
		[HttpPost]
		public ActionResult KategoriEdit(TblKategori t)
		{
			var k = db.TblKategori.Find(t.Id);
			k.Ad = t.Ad;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}