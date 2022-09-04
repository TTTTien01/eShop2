using AutoMapper;
using AutoMapper.QueryableExtensions;
using eShop.Areas.Admin.ViewModels.Category;
using eShop.Database;
using eShop.Database.Entities;
using eShop.WebConfigs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Areas.Admin.Controllers
{
	public class CategoryController : BaseController
	{
		private readonly IMapper _mapper;

		public CategoryController(AddDbContext db, IMapper mapper) : base(db)
		{
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			var query = _db.ProductCategories
				.ProjectTo<ListItemCategoryVM>(AutoMapperProfile.CategoryConfig)
				.OrderByDescending(c => c.Id);
			ViewBag.Sql = query.ToQueryString();
			var data = query.ToList();
			return View("Index", data);
		}
		public IActionResult Create() => View();//đối hàm có hàm return có thể viết giống như này 

		[HttpPost]
		public IActionResult Create(AddOrUpdateCategoryVM categoryVM, ProductCategory category)
		{
			//xac thuc du lieu
			if (ModelState.IsValid == false)
			{
				return View(categoryVM);
			}
			//luu vao db
			//var category = new ProductCategory();//tao bien moi de lk voi view model
			_mapper.Map(categoryVM, category);

			category.CreatedAt = DateTime.Now;
			category.UpdatedAt = DateTime.Now;
			_db.ProductCategories.Add(category);
			_db.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			//Không ch xóa nếu DM đã có sản phẩm 
			if(_db.Products.Any(p => p.CategoryId == id))
			{
				//gửi dl chỉ 1 lần
				TempData["Error"] = "Danh mục đã được sử dụng, không thể xóa";
				
				return RedirectToAction(nameof(Index));
			}	

			var category = _db.ProductCategories.Find(id);
			if (category != null)
			{
				TempData["SuccesMes"] = "Xóa thành công";
				_db.ProductCategories.Remove(category);
				_db.SaveChanges();
			}
			//
			return RedirectToAction(nameof(Index));
		}
		
		public IActionResult Edit(int id)
		{
			var category = _db.ProductCategories
				.ProjectTo<AddOrUpdateCategoryVM>(AutoMapperProfile.CategoryConfig)
				.FirstOrDefault(c => c.Id ==id);
			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(int id, AddOrUpdateCategoryVM categoryVM)
		{
			if(!ModelState.IsValid)
			{
				return View(categoryVM);
			}
			var category = _db.ProductCategories.Find(id);

			if(category!= null)
			{
				_mapper.Map(categoryVM, category);
				category.UpdatedAt = DateTime.Now;
				_db.SaveChanges();
			}
			return RedirectToAction(nameof(Index));
			
		}
	}
 }

