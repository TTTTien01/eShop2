using AutoMapper;
using AutoMapper.QueryableExtensions;
using eShop.Areas.Admin.ViewModels.Product;
using eShop.Database;
using eShop.Database.Entities;
using eShop.WebConfigs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eShop.Areas.Admin.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IMapper _mapper;	

		public ProductController(AddDbContext db, IMapper mapper) : base(db)
		{
			_mapper = mapper;
		}


		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var method = context.HttpContext.Request.Method;
			if(method == HttpMethod.Post.Method)
			{
				if(!ModelState.IsValid)
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



		public List<ListItemProductVM> GetAll()
		{
			var query = _db.Products
				.ProjectTo<ListItemProductVM>(AutoMapperProfile.ProductConfig)
				.OrderByDescending(p => p.Id);
			var data = query.ToList();

			return data;
		}


		[HttpPost]
		public IActionResult CreateProduct([FromBody] AddOrUpdateProductVM productVM, Product product)
		{
			if(ModelState.IsValid == false)
			{
				return Ok(new
				{
					success = false,
					msg = "Them san pham that bai!!!!!"
				});
			}

			_mapper.Map(productVM,product);
			product.CreatedAt = DateTime.Now;	
			product.UpdatedAt = DateTime.Now;
			_db.Products.Add(product);
			_db.SaveChanges();
			return Ok(new
			{
				success = true
			});
		}


		public IActionResult DeleteProduct(int id, Product product)
		{
			_db.Products.Find(id);	
			if(product != null)
			{
				_db.Products.Remove(product);
				_db.SaveChanges();
			}
			return Ok(new
			{
				success = true,
			}) ;
		}



		public IActionResult GetForUpdateProduct(int id, Product product)
		{
			_db.Products.ProjectTo<ListItemProductVM>(AutoMapperProfile.ProductConfig)	
				.FirstOrDefault(p =>p.Id == id);
			return Ok(product);
		}


		[HttpPost]
		public IActionResult EditProduct(int id, [FromBody]AddOrUpdateProductVM productVM, Product product)
		{
			if(ModelState.IsValid )
			{
				return Ok(new
				{
					success = false,
					msg = "Update that bai!!!"
				});
			}
			 _db.Products.Find(id);
			if(product != null)
			{
				_mapper.Map(productVM, product);
				product.UpdatedAt = DateTime.Now;
				_db.SaveChanges();
			}
			return Ok(new
			{
				success = true
			});

		}
	}
}
