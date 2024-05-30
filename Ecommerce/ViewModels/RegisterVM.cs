using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn chưa nhập tên đăng nhập")]
        [MaxLength(20,ErrorMessage ="Tối đa 20 kí tự" )]
        public string MaKh { get; set; }

        [Display(Name ="Mật Khẩu")]
        [Required(ErrorMessage ="Bạn chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string? MatKhau { get; set; }

        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="Bạn chưa nhập Họ Tên")]
        [MaxLength(50,ErrorMessage ="Tối đa 50 ký tự")]
        public string HoTen { get; set; } 

        public bool GioiTinh { get; set; } = true;

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }


        [Display(Name ="Địa chỉ")]
        [Required(ErrorMessage="Bạn chưa nhập địa chỉ")]
        [MaxLength(60, ErrorMessage = "Tối đa 60 ký tự")]
        public string? DiaChi { get; set; }

        [Display(Name = "Điện thoại")]
        [MaxLength(24, ErrorMessage = "Tối đa 24 ký tự")]
        [Required(ErrorMessage ="Bạn chưa nhập thông tin số điện thoại")]
        [RegularExpression(@"0[98753]\d{8}", ErrorMessage ="Chưa đúng định dạnh di động")]
        public string? DienThoai { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập thông tin Email")]
        [EmailAddress(ErrorMessage ="Chưa đúng định dạng email")]
        public string Email { get; set; }

        public string? Hinh { get; set; }

    }
}
