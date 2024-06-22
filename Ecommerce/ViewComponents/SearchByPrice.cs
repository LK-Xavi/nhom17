using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Components
{
    public class SearchByPriceViewComponent : ViewComponent
    {
        private readonly EshopContext db;

        public SearchByPriceViewComponent(EshopContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(decimal? minPrice, decimal? maxPrice)
        {
            var hangHoas = db.HangHoas.AsQueryable();

            // Chuyển đổi minPrice và maxPrice sang kiểu double?
            double? minPriceDouble = (double?)minPrice;
            double? maxPriceDouble = (double?)maxPrice;

            if (minPriceDouble.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.DonGia >= minPriceDouble.Value);
            }

            if (maxPriceDouble.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.DonGia <= maxPriceDouble.Value);
            }

            var result = await hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHH = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            }).ToListAsync();

            return View(result);
        }
    }
}
