using AutoMapper;
using eShop.Areas.Admin.ViewModels.Category;
using eShop.Areas.Admin.ViewModels.Product;
using eShop.Database.Entities;

namespace eShop.WebConfigs
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			//Cấu hình các class đc phép map
			CreateMap<ProductCategory, AddOrUpdateCategoryVM>().ReverseMap();

			CreateMap<Product, AddOrUpdateProductVM>().ReverseMap();
		}
		public static MapperConfiguration CategoryConfig = new MapperConfiguration(opt =>
		{
			opt.CreateMap<ProductCategory, AddOrUpdateCategoryVM>();
			opt.CreateMap<ProductCategory, ListItemCategoryVM>();

		});

		public static MapperConfiguration ProductConfig = new MapperConfiguration(opt =>
		{
			opt.CreateMap<Product, AddOrUpdateProductVM>();
			opt.CreateMap<Product, ListItemProductVM>()
			.ForMember(vm => vm.CategoryName, opt => opt.MapFrom(entity => entity.ProductCategory == null ? "" : entity.ProductCategory.Name));
		});

		
    }
}
