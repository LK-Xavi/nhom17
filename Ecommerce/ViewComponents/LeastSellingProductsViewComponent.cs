
using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerce.Components
{
    public class LeastSellingProductsViewComponent : ViewComponent
    {
        private readonly EshopContext db;

        public LeastSellingProductsViewComponent(EshopContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            var leastSellingProducts = db.HangHoas
                .OrderBy(p => p.SoLuotMua) // Sắp xếp theo số lượt mua tăng dần
                .Take(3) // Lấy 3 sản phẩm có lượt mua thấp nhất
                .Select(p => new HangHoa
                {
                    MaHh = p.MaHh,
                    TenHh = p.TenHh,
                    DonGia = (double)(p.DonGia ?? 0),
                    Hinh = p.Hinh ?? "",
                    MoTa = p.MoTaDonVi ?? "",
                    MaLoai = p.MaLoai,
                    SoLuotMua = p.SoLuotMua,        
                }).ToList();

            return View(leastSellingProducts);
        }
    }
}
