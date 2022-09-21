namespace eShop.Areas.Admin.ViewModels.Product
{
    public class ListItemProductVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

		public string? Description { get; set; }//mô tả

		public string? Price { get; set; }

		public string? DiscountPrice { get; set; }//giảm giá

		public string? CoverImg { get; set; }

		public int? InStock { get; set; } //tồn kho

		public int? CategoryId { get; set; }

		public DateTime? CreateAt { get; set; }
    }
}
