using Microsoft.AspNetCore.Mvc;
using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly EshopContext db;
        public AccountController(EshopContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.KhachHangs.SingleOrDefaultAsync(u => u.MaKh == model.UserName && u.MatKhau == model.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.MaKh), // Set MaKh to User.Identity.Name
                        new Claim(ClaimTypes.NameIdentifier, user.MaKh.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "login");

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties { IsPersistent = true });

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}

