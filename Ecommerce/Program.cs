using Ecommerce.Data;
using Ecommerce.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm các d?ch v? vào container.
// ??ng ký d?ch v? cho các b? ?i?u khi?n và view.
builder.Services.AddControllersWithViews();

// ??ng ký DbContext v?i chu?i k?t n?i t? c?u hình.
builder.Services.AddDbContext<EshopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Eshop"));
});

// ??ng ký b? nh? phân ph?i (Distributed Memory Cache).
builder.Services.AddDistributedMemoryCache();

// cấu hình session.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// đăng ký AutoMapper với cấu hình AutoMapperProfile.
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


// S? d?ng xác th?c cookie.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/KhachHang/DangNhap"; // ???ng d?n ??n trang ??ng nh?p.
        options.AccessDeniedPath = "/AccessDenied"; // ???ng d?n ??n trang t? ch?i truy c?p.
    });

// Cấu hình dich vụ ủy quyền.
// Thêm các chính sách ?y quy?n d?a trên vai trò.
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("KhachHang", policy => policy.RequireRole("KhachHang"));
    options.AddPolicy("NhanVien", policy => policy.RequireRole("NhanVien"));
});

var app = builder.Build();

// C?u hình pipeline x? lý HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // X? lý ngo?i l?.
    app.UseHsts(); // S? d?ng HSTS cho b?o m?t.
}

app.UseHttpsRedirection(); // Chuy?n h??ng HTTP sang HTTPS.
app.UseStaticFiles(); // S? d?ng các t?p t?nh.

app.UseRouting(); // S? d?ng routing.

app.UseSession(); // S? d?ng session.

app.UseAuthentication(); // S? d?ng xác th?c.
app.UseAuthorization(); // S? d?ng ?y quy?n.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // ??nh ngh?a route m?c ??nh.

app.Run(); // Ch?y ?ng d?ng.
