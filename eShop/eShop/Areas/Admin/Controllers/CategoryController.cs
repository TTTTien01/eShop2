using eShop.Database;
using eShop.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Areas.Admin.Controllers
{
	public class CategoryController : BaseController
	{
		public CategoryController(AppDbContext db) : base(db)
		{ 
		}
		public IActionResult Index()
		{
			var data = _db.ProductCategories.OrderByDescending(c => c.Id).ToList();

			return View(data);
		}

		public IActionResult Create() => View();

		[HttpPost]
		public IActionResult Create(ProductCategory category)
		{
			category.CreatedAt = DateTime.Now;
			category.UpdateAt = DateTime.Now;	
			_db.ProductCategories.Add(category);
			_db.SaveChanges();	
			return RedirectToAction(nameof(Index));
		}
	}
}
