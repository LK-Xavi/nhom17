using Ecommerce.Data;

namespace Ecommerce.ViewModels
{
    public class CartItem
    {
        public int MaGioHang { get; set; }
        public int MaHh { get; set; }
        public string MaKh { get; set; }

        public string Hinh { get; set; }

        public string TenHH { get; set; }

        public double DonGia { get; set; }

        public int SoLuong { get; set; }

        public double ThanhTien => SoLuong * DonGia;
        public virtual KhachHang MaKhNavigation { get; set; } = null!;
        public virtual HangHoa MaHhNavigation { get; set; } = null!;


    }
}
