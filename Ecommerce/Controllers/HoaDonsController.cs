using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Microsoft.AspNetCore.Authorization;
using Azure;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace Ecommerce.Controllers
{
    [Authorize(Policy = "NhanVien")]
    public class HoaDonsController : Controller
    {
        private readonly EshopContext _context;

        public HoaDonsController(EshopContext context)
        {
            _context = context;
        }

        // Thống kê theo ngày
        public ActionResult ByDay(DateTime date)
        {
            var orders = _context.HoaDons.Where(h => h.NgayDat == date).Select(h => new Billdetail
            {
                MaHd = h.MaHd,
                NgayDat = h.NgayDat,
                HoTen = h.HoTen,
                DiaChi = h.DiaChi,
                PhiVanChuyen = h.PhiVanChuyen,
                CachThanhToan = h.CachThanhToan,
                CachVanChuyen = h.CachVanChuyen,
                SoLuong = ViewModels.Billdetail.getSoLuongfromHD(h.MaCt,_context),
                DonGia = ViewModels.Billdetail.getDonGiafromHD(h.MaCt,_context),
                TrangThai = ViewModels.Billdetail.convertMaTrangThaitoTrangThai(h.MaTrangThai),
            }).ToList();
            
            var orderCount = orders.Count();

            ViewBag.Date = date;
            ViewBag.OrderCount = orderCount;
           
    
            return View(orders);
        }

        // Thống kê theo tháng
        public ActionResult ByMonth(int month, int year)
        {
            var orders = _context.HoaDons.Where(h => h.NgayDat.Month == month && h.NgayDat.Year == year).Select(h => new Billdetail
            {
                MaHd = h.MaHd,
                NgayDat = h.NgayDat,
                HoTen = h.HoTen,
                DiaChi = h.DiaChi,
                PhiVanChuyen = h.PhiVanChuyen,
                CachThanhToan = h.CachThanhToan,
                CachVanChuyen = h.CachVanChuyen,
                SoLuong = ViewModels.Billdetail.getSoLuongfromHD(h.MaCt, _context),
                DonGia = ViewModels.Billdetail.getDonGiafromHD(h.MaCt, _context),
                TrangThai = ViewModels.Billdetail.convertMaTrangThaitoTrangThai(h.MaTrangThai),
            }).ToList();
            var orderCount = orders.Count();

            ViewBag.Month = month;
            ViewBag.Year = year;
            ViewBag.OrderCount = orderCount;

            return View(orders);
        }

        // Thống kê theo năm
        public ActionResult ByYear(int year)
        {
            var orders = _context.HoaDons.Where(h => h.NgayDat.Year == year).Select(h => new Billdetail
            {
                MaHd = h.MaHd,
                NgayDat = h.NgayDat,
                HoTen = h.HoTen,
                DiaChi = h.DiaChi,
                PhiVanChuyen = h.PhiVanChuyen,
                CachThanhToan = h.CachThanhToan,
                CachVanChuyen = h.CachVanChuyen,
                SoLuong = ViewModels.Billdetail.getSoLuongfromHD(h.MaCt, _context),
                DonGia = ViewModels.Billdetail.getDonGiafromHD(h.MaCt, _context),
                TrangThai = ViewModels.Billdetail.convertMaTrangThaitoTrangThai(h.MaTrangThai),
            }).ToList();
            var orderCount = orders.Count();

            ViewBag.Year = year;
            ViewBag.OrderCount = orderCount;
            

            return View(orders);
        }
        // GET: HoaDons
        public async Task<IActionResult> Index()
        {
            var eshopContext = _context.HoaDons.Include(h => h.MaKhNavigation).Include(h => h.MaNvNavigation).Include(h => h.MaTrangThaiNavigation);
            return View(await eshopContext.ToListAsync());
        }

        // GET: HoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaNvNavigation)
                .Include(h => h.MaTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public IActionResult Create()
        {
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh");
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv");
            ViewData["MaTrangThai"] = new SelectList(_context.TrangThais, "MaTrangThai", "MaTrangThai");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHd,MaKh,NgayDat,NgayCan,NgayGiao,HoTen,DiaChi,CachThanhToan,CachVanChuyen,PhiVanChuyen,MaTrangThai,MaNv,GhiChu")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra sự tồn tại của các khóa ngoại
                if (!_context.KhachHangs.Any(kh => kh.MaKh == hoaDon.MaKh))
                {
                    ModelState.AddModelError("MaKh", "Khách hàng không tồn tại.");
                    return View(hoaDon);
                }

                if (!_context.NhanViens.Any(nv => nv.MaNv == hoaDon.MaNv))
                {
                    ModelState.AddModelError("MaNv", "Nhân viên không tồn tại.");
                    return View(hoaDon);
                }

                if (!_context.TrangThais.Any(tt => tt.MaTrangThai == hoaDon.MaTrangThai))
                {
                    ModelState.AddModelError("MaTrangThai", "Trạng thái không tồn tại.");
                    return View(hoaDon);
                }

                try
                {
                    _context.Add(hoaDon);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Không thể lưu thay đổi: " + ex.Message);
                }
            }
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", hoaDon.MaKh);
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv", hoaDon.MaNv);
            ViewData["MaTrangThai"] = new SelectList(_context.TrangThais, "MaTrangThai", "MaTrangThai", hoaDon.MaTrangThai);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", hoaDon.MaKh);
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv", hoaDon.MaNv);
            ViewData["MaTrangThai"] = new SelectList(_context.TrangThais, "MaTrangThai", "MaTrangThai", hoaDon.MaTrangThai);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHd,MaKh,NgayDat,NgayCan,NgayGiao,HoTen,DiaChi,CachThanhToan,CachVanChuyen,PhiVanChuyen,MaTrangThai,MaNv,GhiChu")] HoaDon hoaDon)
        {
            if (id != hoaDon.MaHd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.MaHd))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", hoaDon.MaKh);
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv", hoaDon.MaNv);
            ViewData["MaTrangThai"] = new SelectList(_context.TrangThais, "MaTrangThai", "MaTrangThai", hoaDon.MaTrangThai);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaNvNavigation)
                .Include(h => h.MaTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDons.Remove(hoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.MaHd == id);
        }
    }
}
