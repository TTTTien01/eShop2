using eShop.Database.Entities.Base;

namespace eShop.Database.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }//mô tả
        public string? Price { get; set; }
        public string? DiscountPrice { get; set; }
        public string? CoverImg { get; set; }
        public int? InStock { get; set; }
        public int? CategoryId { get; set; }//khóa ngoại
        public ProductCategory? ProductCategory { get; set; }
    }
}
