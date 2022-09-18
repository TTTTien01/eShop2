using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eShop.Areas.Admin.ViewModels.Category
{
    public class AddOrUpdateCategoryVM
    {
         public int Id { get; set; }
        //xac thuoc du lieu
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [MinLength(3,ErrorMessage ="{0} không được ít hơn 3 kí tự")]
        [DisplayName("Tên danh mục")]

        public string? Name { get; set; }
        
    }
}
