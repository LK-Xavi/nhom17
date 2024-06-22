using Ecommerce.Data;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ViewComponents
{
    public class list : ViewComponent
    {
        private readonly EshopContext db;

        public list(EshopContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = db.HangHoas.Select(l => new HangHoaVM
            {
                MaHh = l.MaHh,
                TenHH = l.TenHh
            });
               
               return View(data);
          


            
        }
    }
}
