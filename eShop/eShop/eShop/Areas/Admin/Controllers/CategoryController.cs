using AutoMapper;
using AutoMapper.QueryableExtensions;
using eShop.Areas.Admin.ViewModels.Category;
using eShop.Database;
using eShop.Database.Entities;
using eShop.WebConfigs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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


		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var method = context.HttpContext.Request.Method;
			if (method == HttpMethod.Post.Method)
			{
				if (!ModelState.IsValid )
				{
					var x = ModelState.Values.Where(x => x.Errors
					.Where(y => !String.IsNullOrEmpty(y.ErrorMessage))
					.Count() > 0).ToList();
					var errModel = new SerializableError(ModelState);
					context.Result = new BadRequestObjectResult(errModel);
				}
			}
		}


		public IActionResult Index()
		{
			return View();	
		}



		public List<ListItemCategoryVM> GetAll()
		{
			var query = _db.ProductCategories
				.ProjectTo<ListItemCategoryVM>(AutoMapperProfile.CategoryConfig)
				.OrderByDescending(c => c.Id);
			var data = query.ToList();

			return data;
		}



		[HttpPost]
		public IActionResult Create([FromBody] AddOrUpdateCategoryVM categoryVM,ProductCategory category)
		{
			//xac thuc du lieu
			if (ModelState.IsValid == false)
			{
				return Ok(new
				{
					success = false,
					msg = "Thêm thất bại"
				});
			}
			//luu vao db
			//var category = new ProductCategory();//tao bien moi de lk voi view model
			_mapper.Map(categoryVM, category);

			category.CreatedAt = DateTime.Now;
			category.UpdatedAt = DateTime.Now;
			_db.ProductCategories.Add(category);
			_db.SaveChanges();
			return Ok(new
			{
				success = true,
			});
		}



		public IActionResult Delete(int id)
		{
			//Không cho xóa nếu DM đã có sản phẩm 
			if(_db.Products.Any(p => p.CategoryId == id))
			{
				return Ok(new
				{
					success = false,
					msg = "Không được xóa vì danh mục đã được sử dụng"
				});
			}
			else
			{
				var category = _db.ProductCategories.Find(id);
				if (category != null)
				{
					_db.ProductCategories.Remove(category);
					_db.SaveChanges();
				}
				return Ok(new
				{
					success = true,
				});
			}
		}




		public IActionResult GetForUpdate(int id)
		{
			var category = _db.ProductCategories
				.ProjectTo<AddOrUpdateCategoryVM>(AutoMapperProfile.CategoryConfig)
				.FirstOrDefault(c => c.Id == id);
			return Ok(category);
		}




		[HttpPost]
		public IActionResult Edit(int id,[FromBody] AddOrUpdateCategoryVM categoryVM)
		{
			if(!ModelState.IsValid)
			{
				return Ok(new
				{
					success = false,
					msg = "Không cập nhật được"
				});
			}
			var category = _db.ProductCategories.Find(id);

			if(category!= null)
			{
				_mapper.Map(categoryVM, category);
				category.UpdatedAt = DateTime.Now;
				_db.SaveChanges();
			}
			return Ok(new
			{
				success = true,
			});

		}
	}
 }

