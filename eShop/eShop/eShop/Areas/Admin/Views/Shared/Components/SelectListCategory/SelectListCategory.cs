using eShop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eShop.Areas.Admin.Views.Shared.components.SelectListCategory
{
	public class SelectListCategoryViewComponent : ViewComponent
	{
		private readonly AddDbContext _db;

		public SelectListCategoryViewComponent(AddDbContext db)
		{
			_db = db;
		}

		public IViewComponentResult Invoke(string vModel = "")
		{
			var data = _db.ProductCategories
				.OrderByDescending(x => x.Id)
				.ToList();
			var selectList = new SelectList(data,"Id","Name");
			ViewBag.vModel = vModel;
			return View(selectList);
		}

	}
}
