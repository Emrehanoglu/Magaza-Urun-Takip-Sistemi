using MagazaUrunTakipSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class MusteriController : Controller
    {
		DbMagazaUrunTakipEntities db = new DbMagazaUrunTakipEntities();
		public ActionResult Index(int sayfa=1) //baslangıc sayfam 1 olsun
        {
			var musteriler = db.TblMusteri.ToList().ToPagedList(sayfa,3); //1. sayfadan basla ve her sayfada 3 tane veri göster
			return View(musteriler);
        }
		[HttpGet]
		public ActionResult MusteriEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult MusteriEkle(TblMusteri t)
		{
			if (!ModelState.IsValid)
			{
				return View("MusteriEkle");
			}
			db.TblMusteri.Add(t);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult MusteriSil(int id)
		{
			var k = db.TblMusteri.Find(id);
			db.TblMusteri.Remove(k);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult MusteriEdit(int id)
		{
			var k = db.TblMusteri.Find(id);
			return View(k);
		}
		[HttpPost]
		public ActionResult MusteriEdit(TblMusteri t)
		{
			var k = db.TblMusteri.Find(t.Id);
			k.Ad = t.Ad;
			k.Soyad = t.Soyad;
			k.Sehir = t.Sehir;
			k.Bakiye = t.Bakiye;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}