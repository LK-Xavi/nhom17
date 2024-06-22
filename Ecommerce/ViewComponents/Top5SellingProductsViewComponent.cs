using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerce.Components
{
    public class Top5SellingProductsViewComponent : ViewComponent
    {
        private readonly EshopContext db;

        public Top5SellingProductsViewComponent(EshopContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            var top5SellingProducts = db.HangHoas
                .OrderByDescending(p => p.SoLuotMua) // Sắp xếp theo số lượt mua giảm dần
                .Take(3) // Lấy 5 sản phẩm bán chạy nhất
                .Select(p => new HangHoa
                {
                    MaHh = p.MaHh,
                    TenHh = p.TenHh,
                    DonGia = (double)(p.DonGia ?? 0),
                    Hinh = p.Hinh ?? "",
                    MoTa = p.MoTaDonVi ?? "",
                    MaLoai = p.MaLoai,                    
                    SoLuotMua = p.SoLuotMua

                }).ToList();

            return View(top5SellingProducts);
        }
    }
}
