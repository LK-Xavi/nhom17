﻿namespace Ecommerce.ViewModels

{
    
    public class HangHoaVM
    {
        public int MaHh { get; set; }

        public string TenHH { get; set; }

        public string Hinh { get; set;}

        public double DonGia { get; set;}

        public string MoTaNgan { get; set;}

        public string TenLoai { get; set;}

        public double GiamGia { get; set; }


        public int SoLanXem { get; set; }
        public int SoLuotMua { get; set; }
        public string? MoTa { get; set; }
        public string MaNcc { get; set; } 
        public string NgaySX { get; set;}
        public int MaLoai { get; set; }
    }


    public class ChiTietHangHoaVM
    {
        public int MaHh { get; set; }
        public string TenHH { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }

        public string MoTaNgan { get; set; }

        public string TenLoai { get; set; }

        public string ChiTiet {  get; set; }

        public int DiemDanhGia { get; set; }

        public int SoLuongTon { get; set; }

        public List<HangHoaVM> HangHoasCungLoai { get; set; } // Danh sách sản phẩm cùng loại
    }
}
