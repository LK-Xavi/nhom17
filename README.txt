//Cập nhật lại database trên visual studio
//Mở package manager Console

Add-Migration UpdateHangHoaMaCT
Updata-databse

//Sau khi chạy thì gặp lỗi này Bảng khachHang có sẵn rồi nên k có ảnh hưởng
Error Number:2714,State:6,Class:16
There is already an object named 'KhachHang' in the database.


//Actice multiple result
//Trong file appsetting.json phần connectionString database
  "ConnectionStrings": {
    "Eshop": "Data Source=GIAP;Initial Catalog=Eshop;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;"
  },

//Thêm MultipleActiveResultSets=true 
  "ConnectionStrings": {
    "Eshop": "Data Source=GIAP;Initial Catalog=Eshop;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;MultipleActiveResultSets=true "
  },