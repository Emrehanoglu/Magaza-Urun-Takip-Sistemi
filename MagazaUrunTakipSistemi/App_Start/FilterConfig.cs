using System.Web;
using System.Web.Mvc;

namespace MagazaUrunTakipSistemi
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
