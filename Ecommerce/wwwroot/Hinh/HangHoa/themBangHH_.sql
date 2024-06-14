SET IDENTITY_INSERT [dbo].[HangHoa] ON;
go
INSERT INTO [dbo].[HangHoa] 
([MaHH], [TenHH], [TenAlias], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [SoLanXem], [MoTa], [MaNCC]) 
VALUES

    (4000, N'Bàn chải cho bé 2 - 5 tuổi Colgate hình ảnh Minion vui nhộn', N'', 1009, N'1 chiec', 31000, N'ban chai minion cho be.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 3000, N' Bàn chải cho bé 2 - 5 tuổi Colgate hình ảnh Minion vui nhộn mang đến trải nghiệm đánh răng nhẹ nhàng, thoải mái cho bé.', N'BHX'),
    (4001, N'Kem đánh răng cho bé trên 2 tuổi Colgate hương dâu', N'', 1009, N'40g', 9000, N'kem danh rang cho be tren 2 tuoi huong dau.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 1000, N' Kem đánh răng cho bé ngừa sâu răng, bảo vệ men răng cho bé tối ưu cho bé 2-5 tuổi. Kem đánh răng Colgate là sản phẩm được các nha sĩ khuyên dùng, giúp bảo vệ hàm răng bé vượt trội. ', N'BHX'),
    (4002, N'Tắm gội cho bé Lactacyd Milky 250ml', N'', 1009, N'250ml', 99000, N'tam goi cho be lactacyd.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 1500, N' Tắm gội cho bé Lactacyd với hương thơm dịu nhẹ, không làm hại đến làn da mỏng manh của bé. Tắm gội cho bé giúp bé yêu luôn sạch sẽ, thơm tho, dưỡng ẩm, ngừa rôm sẩy.', N'BHX'),
   
    (4003, N'Tắm gội toàn thân cho bé Johnsons Baby ', N'', 1009, N'500ml', 171000, N'tam goi toan than cho be jonsons baby.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 5000, N'Johnsons Baby từ lâu đã là thương hiệu dành cho em bé hàng đầu, đặc biệt là các sản phẩm tắm gội cho bé. Cực kỳ an toàn, dịu nhẹ và phù hợp với làn da của bé.', N'BHX'),
    (4004, N'Kem đánh răng cho bé từ 3 - 5 tuổi Colgate hương dâu', N'', 1009, N'80g', 45000, N'kem danh rang tu 3_5 tuoi huong dau.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 300, N' Kem đánh răng cho bé Colgate ngừa sâu răng, bảo vệ men răng cho bé tối ưu. Kem đánh răng cho bé giúp bảo vệ hàm răng bé vượt trội. ', N'BHX'),
    (4005, N'Bàn chải cho bé 5 - 9 tuổi Colgate Batman lông siêu mềm', N'', 1009, N'1 chiec', 36000, N'ban chai batman.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 2300, N' Là sản phẩm bàn chải cho bé thuộc thương hiệu bàn chải cho bé Colgate. Bàn chải cho bé 5 - 9 tuổi Colgate Batman được thiết kế theo nhân vật hoạt hình mà các bé yêu thích.', N'BHX'),

    (4006, N'Bột giặt Surf nước hoa duyên dáng trắng sạch ngát hương', N'', 1010, N'5.3kg', 139000, N'bot-giat-surf-nuoc-hoa-duyen-dang-trang-sach-ngat-huong.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 500, N' Với công nghệ tinh chế từ Pháp thấm sâu vào từng sợi vải, ngát hương từ khi giặt đến khi mặc, bột giặt Surf là thương hiệu bột giặt rất được ưa chuộng vì an toàn cho làn da khi sử dụng.  ', N'BHX'),
    (4007, N'Nước tẩy bồn cầu & nhà tắm VIM diệt khuẩn', N'', 1010, N'880ml', 34000, N'nuoc tay bon cau vim.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 1300, N'Các sản phẩm tẩy rửa nhà cửa của VIM được các chị em nội trợ cực kỳ ưa chuộng. Tẩy rửa bồn cầu nhà tắm VIM giúp diệt vi khuẩn hiệu quả, ngăn ngừa mảng bám, vết ố. ', N'BHX'),
    (4008, N'Viên treo bồn cầu VIM Power hương chanh ', N'', 1010, N'55g', 28000, N'vien treo bon cau VIM.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 100, N'Viên treo vệ sinh bồn cầu VIM là sản phẩm giúp vệ sinh bồn cầu thông minh, tiện lợi. Mỗi lần nhấn nước xả, Viên treo vệ sinh bồn cầu giúp bồn cầu sẽ nhanh chóng thơm mát, sạch vi khuẩn, ngừa mảng bám.', N'BHX'),

    (4009, N'4 cuộn túi đựng rác đen quai xách Inochi 46x63cm', N'', 1011, N'4 cuộn', 75000, N'4 cuon tui dung rac.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 150, N'Được sản xuất từ chất liệu nhựa cao cấp, không hóa chất, khó rách, giữa các túi rác Inochi có gân sọc dễ dàng xé, tách túi rác mỗi khi muốn sử dụng.', N'BHX'),
    (4010, N'Giấy chống dính Bách hóa XANH 30cm x 5m', N'', 1011, N'1 cuộn', 26500, N'Giay chong dinh bhx.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 100, N'Màng bọc thực phẩm Bách hóa XANH là hãng sản xuất màng bọc thực phẩm có tiếng tại Việt Nam, được nhiều khách hàng tin tưởng chọn lựa.  ', N'BHX'),
    (4011, N'Túi zipper khóa bấm Inochi 18cm x 22.5cm (20 túi)', N'', 1011, N'20 túi', 27000, N'tui zipper inochi.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 234, N'Túi zipper Inochi được làm hoàn toàn từ chất liệu nhựa an toàn nên túi zipper bảo quản tốt khi tiếp xúc với thực phẩm. Túi zipper khóa bấm Inochi 18cm x 22.5cm (20 túi) có khóa có bấm dễ sử dụng, tiện dụng, bảo quản được cho rau củ quả tươi lâu, giữ vệ sinh.', N'BHX'),

    (4012, N'Băng keo đục Thiên Long BKD06/FO', N'', 1011, N'1 cuộn', 17000, N'bawng keo duc TL.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 3245, N'Băng keo Thiên Long được sản xuất theo công nghệ hiện đại, thân thiện với môi trường. Băng keo với màng BOPP có độ bền dai cao, độ dính cao, khả năng đàn hồi tốt.', N'BHX'),
    (4013, N'Tạp dề tráng nhựa Vạn Năng TD 01 (50x65cm)', N'', 1011, N'1 chiếc', 46000, N'tap-de-trang-nhua-van-nang-td.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 345, N'Tạp dề bằng nhựa giúp dễ dàng vệ sinh, không lo bị dầu mỡ dính lên. Tạp dề tráng nhựa Vạn Năng TD 01 (50x65cm) dùng đeo trên cơ thể, tránh những vết bẩn khi làm bếp. Tạp dề Vạn Năng tiện lợi, dễ dàng sử dụng.', N'BHX'),
    (4014, N'Khăn lau đa năng Nano kháng khuẩn hương tự nhiên túi', N'', 1011, N'30 tờ', 24000, N'khan lau da nang nanno.jpg', CAST(N'2024-05-25T07:00:00.000' AS DateTime), 0, 3563, N'Giấy lau bếp Nano với công thức đặc biệt giúp lau bếp hiệu quả, sạch nhanh, sạch nhẹ nhàng các vết bẩn cứng đầu, vết dầu mỡ bám xung quanh hoặc các vết cháy khét xung quanh căn bếp.', N'BHX')

SET IDENTITY_INSERT [dbo].[HangHoa] OFF;

--select * from HangHoa
