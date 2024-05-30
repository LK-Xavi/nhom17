using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly EshopContext db;
        public MenuLoaiViewComponent(EshopContext context) => db = context; 

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count
            }).OrderBy(p => p.MaLoai);

            return View(data); // Default.cshtml

        }
    }
}
