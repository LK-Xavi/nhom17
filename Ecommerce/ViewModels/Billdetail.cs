using Ecommerce.Data;

namespace Ecommerce.ViewModels
{
    public class Billdetail
    {
        public int MaHd { get; set; }
        public DateTime NgayDat { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public double PhiVanChuyen { get; set; }
        public string CachThanhToan {  get; set; }
        public string CachVanChuyen { get; set; }
        public string TrangThai {  get; set; }  
        public int SoLuong { get; set; }
        public  double DonGia { get; set; }
        public double ThanhTien {
            get
            {
                return SoLuong*DonGia;
            }
            set
            {
                ThanhTien = DonGia * SoLuong;
            }
        }
        public static double getDonGiafromHD(int maCT, EshopContext context )
        {
            if ( maCT < 0 ) { return 0; }
            else
            {
                List<double> dongia = context.ChiTietHds.Where(h => h.MaCt == maCT).Select(h => h.DonGia).ToList();
                if (dongia == null) { return 0; }
                else return dongia[0];
            }
        }
        public static int getSoLuongfromHD(int maCT, EshopContext context) { 
            if (maCT < 0) { return 0; } else
            {
                List<int> soluong = context.ChiTietHds.Where(h => h.MaCt == maCT).Select(h => h.SoLuong).ToList();
                if (soluong == null) {return 0; }
                else return soluong[0];
            }
        }

        public static string convertMaTrangThaitoTrangThai(int MaTrangThai)
        {
            if (MaTrangThai == -1)
                return "Khách hàng hủy đơn hàng";
            else if (MaTrangThai == 0) return "Mới đặt hàng";
            else if (MaTrangThai == 1) return "Đã thanh toán";
            else if (MaTrangThai == 2) return "Chờ giao hàng";
            else if (MaTrangThai == 3) return "Đã giao hàng";
            else return "Khách hàng hủy đơn hàng";
        }
    }
}
