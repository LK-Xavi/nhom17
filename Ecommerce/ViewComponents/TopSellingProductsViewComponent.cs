using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerce.Components
{
    public class TopSellingProductsViewComponent : ViewComponent
    {
        private readonly EshopContext db;

        public TopSellingProductsViewComponent(EshopContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
        var hangHoas = db.HangHoas
                .OrderByDescending(p => p.SoLuotMua)  // Sắp xếp theo số lần mua giảm dần
                .Take(10)  // Giới hạn số lượng sản phẩm muốn hiển thị
                .Select(p => new HangHoaVM
                {
                    MaHh = p.MaHh,
                    TenHH = p.TenHh,
                    DonGia = (double)(p.DonGia ?? 0),
                    Hinh = p.Hinh ?? "",
                    MoTaNgan = p.MoTaDonVi ?? "",
                    TenLoai = p.MaLoaiNavigation.TenLoai,
                    SoLanXem = p.SoLanXem,
                    SoLuotMua = p.SoLuotMua
                }).ToList();
            return View(hangHoas);
        }
    }
}
