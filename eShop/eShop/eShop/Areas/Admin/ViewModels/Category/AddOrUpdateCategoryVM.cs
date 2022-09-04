using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eShop.Areas.Admin.ViewModels.Category
{
    public class AddOrUpdateCategoryVM
    {
         public int Id { get; set; }
        //xac thuoc du lieu
        [Required(ErrorMessage = "{0} la bat buoc")]
        [MinLength(3,ErrorMessage ="{0} Khong duoc it hon 3 ki tu")]
        [DisplayName("Ten danh muc")]

        public string? Name { get; set; }
        
    }
}
