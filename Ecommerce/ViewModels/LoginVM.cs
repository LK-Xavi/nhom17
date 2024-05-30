using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Chưa điền thông tin")]
        [MaxLength(20, ErrorMessage ="Tối đa 20 ký tự")]
        public string UserName {  get; set; }

        [Display(Name ="Mật Khẩu")]
        [Required(ErrorMessage ="Chưa điền thông tin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
