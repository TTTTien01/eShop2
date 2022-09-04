using eShop.Database;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AddDbContext _db;
        public BaseController(AddDbContext db)
        {
            _db = db; 
        }
    }
}
