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
