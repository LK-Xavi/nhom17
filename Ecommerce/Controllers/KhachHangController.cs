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
        public IActionResult DangNhap(string ? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        [HttpPost]
            public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
            {
                ViewBag.ReturnUrl = ReturnUrl;
                if (ModelState.IsValid)
                {
                    var khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == model.UserName);
                    if (khachHang == null)
                    {
                        ModelState.AddModelError("loi", "không có khách hàng này");
                        return View();
                    }

                    if (!khachHang.HieuLuc)
                    {
                        ModelState.AddModelError("loi", "Tài khoản đã bị khóa");
                        return View();
                    }

                    if (khachHang.MatKhau != model.Password.ToMd5Hash(khachHang.RandomKey))
                    {
                        ModelState.AddModelError("loi", "sai thông tin đăng nhập");
                        return View();
                    }

                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, khachHang.Email),
                new Claim(ClaimTypes.Name, khachHang.HoTen),
                new Claim(MySetting.CLAIM_CUSTOMERID, khachHang.MaKh),
                new Claim(ClaimTypes.Role, "Customer")
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                return View();
            }

        #endregion

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
