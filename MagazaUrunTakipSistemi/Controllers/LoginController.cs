using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakipSistemi.Models.Entity;
using System.Web.Security;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class LoginController : Controller
    {
		DbMagazaUrunTakipEntities db = new DbMagazaUrunTakipEntities();
		[HttpGet]
		public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult GirisYap(TblAdmin admin)
		{
			var giris = db.TblAdmin.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
			if (giris != null)
			{
				FormsAuthentication.SetAuthCookie(admin.KullaniciAd, false);
				return View("Index","Kategori");
			}
			return View();
		}
	}
}