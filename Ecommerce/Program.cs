using Ecommerce.Data;
using Ecommerce.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm các dịch vụ vào container.
// Đăng ký dịch vụ cho các bộ điều khiển và view.
builder.Services.AddControllersWithViews();

// Đăng ký DbContext với chuỗi kết nối từ cấu hình.
builder.Services.AddDbContext<EshopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Eshop"));
});

// Đăng ký bộ nhớ phân phối (Distributed Memory Cache).
builder.Services.AddDistributedMemoryCache();

// Cấu hình session.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Đăng ký AutoMapper với cấu hình AutoMapperProfile.
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Sử dụng xác thực cookie.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/KhachHang/DangNhap"; // Đường dẫn đến trang đăng nhập.
        options.AccessDeniedPath = "/AccessDenied"; // Đường dẫn đến trang từ chối truy cập.
    });

// Cấu hình dịch vụ ủy quyền.
// Thêm các chính sách ủy quyền dựa trên vai trò.
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("KhachHang", policy => policy.RequireRole("KhachHang"));
    options.AddPolicy("NhanVien", policy => policy.RequireRole("NhanVien"));
});

// Đăng ký HangHoaService


var app = builder.Build();

// Cấu hình pipeline xử lý HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Xử lý ngoại lệ.
    app.UseHsts(); // Sử dụng HSTS cho bảo mật.
}

app.UseHttpsRedirection(); // Chuyển hướng HTTP sang HTTPS.
app.UseStaticFiles(); // Sử dụng các tệp tĩnh.

app.UseRouting(); // Sử dụng routing.

app.UseSession(); // Sử dụng session.

app.UseAuthentication(); // Sử dụng xác thực.
app.UseAuthorization(); // Sử dụng ủy quyền.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Định nghĩa route mặc định.

app.Run(); // Chạy ứng dụng.
