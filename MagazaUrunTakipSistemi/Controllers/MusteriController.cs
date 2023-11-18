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
    }
}