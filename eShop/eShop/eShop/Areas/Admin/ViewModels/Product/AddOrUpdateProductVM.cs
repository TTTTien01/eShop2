using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace eShop.Areas.Admin.ViewModels.Product
{
    public class AddOrUpdateProductVM
    {
         public int Id { get; set; }
        //xac thuoc du lieu
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [MinLength(3,ErrorMessage ="{0} không được ít hơn 3 kí tự")]
        [DisplayName("Tên sản phẩm")]
        public string? Name { get; set; }

		[MinLength(3, ErrorMessage = "{0} không được ít hơn 3 kí tự")]
		[DisplayName("Mô tả sản phẩm")]
		public string? Description { get; set; }//mô tả

		[Required(ErrorMessage = "{0} là bắt buộc")]
		[MinLength(4, ErrorMessage = "{0} không được ít hơn 4 chữ số")]
		[DisplayName("Giá")]
		public string? Price { get; set; }

		[MinLength(1, ErrorMessage = "{0} không được ít hơn 1 chữ số")]
		[DisplayName("Giảm giá")]
		public string? DiscountPrice { get; set; }//giảm giá

		[DisplayName("Hình ảnh")]
		public string? CoverImg { get; set; }

		[DisplayName("Tồn kho")]
		public int? InStock { get; set; } //tồn kho

		[DisplayName("Danh mục")]
		public int? CategoryId { get; set; }

	}
}
