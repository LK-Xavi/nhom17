using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Helpers;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly EshopContext db;
        private readonly IMapper _mapper;
        public KhachHangController(EshopContext context, IMapper mapper) 
        {
             db = context;
            _mapper = mapper;
        }
        #region Register
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(RegisterVM model, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var khachHang = _mapper.Map<KhachHang>(model);
                    khachHang.RandomKey = MyUtil.GenerateRamdomKey();
                    khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);
                    khachHang.HieuLuc = true;
                    khachHang.VaiTro = 0;

                    if (Hinh != null)
                    {
                        khachHang.Hinh = MyUtil.UploandHinh(Hinh, "KhachHang");
                    }

                    db.Add(khachHang);
                    db.SaveChanges();
                    return RedirectToAction("Index", "HangHoa");
                }

                catch (Exception ex)
                {

                }
            }
            return View();
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult DangNhap(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl; // Lưu trữ ReturnUrl trong ViewBag để sử dụng trong View
            return View(); // Trả về View cho trang đăng nhập
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl; // Lưu trữ ReturnUrl trong ViewBag để sử dụng trong View

            if (ModelState.IsValid)
            {
                // Kiểm tra thông tin đăng nhập từ bảng KhachHang
                var khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == model.UserName);
                if (khachHang != null)
                {
                    if (!khachHang.HieuLuc)
                    {
                        ModelState.AddModelError("loi", "Tài khoản đã bị khóa");
                        return View();
                    }

                    if (khachHang.MatKhau != model.Password.ToMd5Hash(khachHang.RandomKey))
                    {
                        ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
                        return View();
                    }

                    // Tạo các claim cho KhachHang
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, khachHang.Email),
                new Claim(ClaimTypes.Name, khachHang.HoTen),
                new Claim("CustomerID", khachHang.MaKh),
                new Claim(ClaimTypes.Role, "KhachHang") // Đặt vai trò là KhachHang
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }

                // Kiểm tra thông tin đăng nhập từ bảng NhanVien
                var nhanVien = db.NhanViens.SingleOrDefault(nv => nv.MaNv == model.UserName);
                if (nhanVien != null)
                {
                    // Không kiểm tra HieuLuc đối với NhanVien

                    // Kiểm tra mật khẩu trực tiếp
                    if (nhanVien.MatKhau != model.Password)
                    {
                        ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
                        return View();
                    }

                    // Tạo các claim cho NhanVien
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, nhanVien.Email),
                new Claim(ClaimTypes.Name, nhanVien.HoTen),
                new Claim("EmployeeID", nhanVien.MaNv),
                new Claim(ClaimTypes.Role, "NhanVien") // Đặt vai trò là NhanVien
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }

                // Nếu không tìm thấy người dùng trong cả hai bảng
                ModelState.AddModelError("loi", "Không tìm thấy người dùng này");
            }

            return View(); // Trả về view nếu ModelState không hợp lệ hoặc thông tin đăng nhập không đúng
        }
        #endregion




        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
