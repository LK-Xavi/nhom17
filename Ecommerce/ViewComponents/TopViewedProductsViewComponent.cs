using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Components
{
    public class TopViewedProductsViewComponent : ViewComponent
    {
        private readonly EshopContext db;

        public TopViewedProductsViewComponent(EshopContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            var hangHoas = db.HangHoas
                .OrderByDescending(p => p.SoLanXem)  // Sắp xếp theo số lượt xem giảm dần
                .Take(10)  // Giới hạn số lượng sản phẩm muốn hiển thị
                .Select(p => new HangHoaVM
                {
                    MaHh = p.MaHh,
                    TenHH = p.TenHh,
                    DonGia = (double)(p.DonGia ?? 0),
                    Hinh = p.Hinh ?? "",
                    MoTaNgan = p.MoTaDonVi ?? "",
                    TenLoai = p.MaLoaiNavigation.TenLoai
                }).ToList();
            return View(hangHoas);
        }


    }
}
