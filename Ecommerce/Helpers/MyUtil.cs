﻿using System.Text;

namespace Ecommerce.Helpers
{
    public class MyUtil
    {
        public static string UploandHinh(IFormFile Hinh, string folder)
        {
            try
            {

                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, Hinh.FileName);
                using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    Hinh.CopyTo(myfile);
                }
                return Hinh.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static string GenerateRamdomKey(int length = 5) 
        {
            var pattern =
                @"qwkjwqkdnkflmfeljniaOSJFMDLVMOIEJFOGRJ!@djksf#";
            var sb = new StringBuilder();
            var rd = new Random();
            for(int i = 0; i < length; i++)
            {
                sb.Append(pattern[rd.Next(0,pattern.Length)]);
            }
            return sb.ToString();
        }
    }
}
