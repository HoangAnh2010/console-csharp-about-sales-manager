using CTBHChoShopMyPham.BussinessLayer;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using CTBHChoShopMyPham.UserInterface.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.UserInterface
{
    class HoaDonUI
    {
        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        
        public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] menu = {
                "1. Thêm hóa đơn.",
                "2. Sửa thông tin hóa đơn.",
                "3. Xóa hóa đơn.",
                "4. Hiển thị danh sách các hóa đơn.",
                "5. Hiển thị chi tiết hóa đơn.",
                "6. Thống kê các hóa đơn được nhập trong ngày.",
                "7. Tìm kiếm hóa đơn.",
                "8. Quay lại trang chủ."
            };
            MenuSelector menuSelector = new MenuSelector("\n\n\n\n\n" + "\t\t\t\t\t\t\t\t\t\t" + "CÁC CHỨC NĂNG VỀ HÓA ĐƠN" + "\n\n", menu);
            bool exit = false;
            while (!exit)
            {
                switch (menuSelector.Chon())
                {
                    case 0:
                        Add();
                        Console.Clear();
                        break;
                    case 1:
                        Update();
                        Console.Clear();
                        break;
                    case 2:
                        Delete();
                        Console.Clear();
                        break;
                    case 3:
                        Show();
                        Console.Clear();
                        break;
                    case 4:
                        ShowDetail();
                        Console.Clear();
                        break;
                    case 5:
                        Statistic();
                        Console.Clear();
                        break;
                    case 6:
                        Search();
                        Console.Clear();
                        break;
                    case 7:
                        exit = true;
                        break;
                }
            }
        }
        public void Add()
        {
            KhachHangUI khachHangUI = new KhachHangUI();
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            ChiTietHoaDonBUS chiTietHoaDonBUS = new ChiTietHoaDonBUS();
            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            List<SanPham> sanPhams = sanPhamBUS.GetList();
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maHD = MaHD1();                
                string maKH = GetMaKH(khachHangUI, khachHangBUS);
                string maNBH = MaNBH();
                DateTime ngayNhap = NgayNhap();
                double tongTien = 0;
                while (true)
                {
                    string maSP = MaSP(sanPhamBUS);
                    int soLuong = SLuong();
                    double thanhTien = chiTietHoaDonBUS.TinhTien(maSP, soLuong, sanPhams, sanPhamBUS);
                    chiTietHoaDonBUS.Add(new ChiTietHoaDon(maHD, maSP, soLuong, thanhTien));
                    tongTien += thanhTien;

                    Console.WriteLine("Bạn có muốn nhập thêm sản phẩm không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                    ConsoleKeyInfo consoleKey = Console.ReadKey();
                    if(consoleKey.Key == ConsoleKey.Escape)
                    {
                        hoaDonBUS.Add(new HoaDon(maHD, maKH, tongTien, ngayNhap, maNBH));
                        Console.CursorVisible = false;                        
                        break;
                    }
                }
                Console.CursorVisible = true;
                Console.WriteLine("Bạn có muốn nhập thêm hóa đơn không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey2 = Console.ReadKey();
                if (consoleKey2.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }                    
            }            
        }
        //Sửa hóa đơn
        public void Update()
        {
            KhachHangUI khachHangUI = new KhachHangUI();
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            ChiTietHoaDonBUS chiTietHoaDonBUS = new ChiTietHoaDonBUS();
            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            List<SanPham> sanPhams = sanPhamBUS.GetList();
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maHD = MaHD2();                
                string maKH = GetMaKH(khachHangUI,khachHangBUS);
                string maNBH = MaNBH();
                DateTime ngayNhap = NgayNhap();
                double tongTien = 0;
                while (true)
                {
                    string maSP = MaSP(sanPhamBUS);
                    int soLuong = SLuong();
                    double thanhTien = chiTietHoaDonBUS.TinhTien(maSP, soLuong, sanPhams, sanPhamBUS);
                    chiTietHoaDonBUS.Add(new ChiTietHoaDon(maHD, maSP, soLuong, thanhTien));
                    tongTien += thanhTien;
                    Console.WriteLine("Bạn có muốn nhập thêm sản phẩm không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                    ConsoleKeyInfo consoleKey = Console.ReadKey();
                    if (consoleKey.Key == ConsoleKey.Escape)
                    {
                        hoaDonBUS.Add(new HoaDon(maHD, maKH, tongTien, ngayNhap, maNBH));

                        Console.CursorVisible = false;
                        break;
                    }
                }
                Console.CursorVisible = true;
                Console.WriteLine("Bạn có muốn sửa hóa đơn nào nữa không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey2 = Console.ReadKey();
                if (consoleKey2.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }
            }
        }
        public void Delete()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maHD = MaHD2();
                hoaDonBUS.Delete(maHD);
                Console.WriteLine("Xóa thành công!");
                Console.WriteLine("Bạn có muốn xóa tiếp không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }
            }
        }
        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                List<HoaDon> hoadon = hoaDonBUS.GetList();
                ChiTietHoaDonBUS cthoaDonBUS = new ChiTietHoaDonBUS();
                List<ChiTietHoaDon> hoaDons = cthoaDonBUS.GetList();

                SanPhamBUS sanPhamBUS = new SanPhamBUS();
                List<SanPham> sanPhams = sanPhamBUS.GetList();

                KhachHangBUS khachHangBUS = new KhachHangBUS();
                List<KhachHang> khachHangs = khachHangBUS.GetList();

                Table table = new Table(150);//Khởi tạo bảng có chiều rộng = 150
                table.PrintLine();
                table.HienThiHang("Mã hóa đơn", "Mã khách hàng", "Số tiền cần thanh toán", "Ngày nhập", "Mã người bán hàng");
                table.PrintLine();
                foreach (var hd in hoadon)//Duyệt các phần tử trong danh sách hóa đơn
                {
                    table.HienThiHang(hd.MaHoaDon, hd.MaKH,hd.TongTien.ToString(), hd.NgayNhap.ToString("MM/dd/yyyy"), hd.MaNBH);
                    table.PrintLine();
                }
                Console.WriteLine("Bấm esc để thoát");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    exit = true;
                }
            }
        }
        public void ShowDetail()
        {            
            
            int kt = 0;
            bool exit = false;
            while (!exit)
            {
                List<HoaDon> hoadon = hoaDonBUS.GetList();

                ChiTietHoaDonBUS cthoaDonBUS = new ChiTietHoaDonBUS();
                List<ChiTietHoaDon> cthoaDons = cthoaDonBUS.GetList();

                SanPhamBUS sanPhamBUS = new SanPhamBUS();
                List<SanPham> sanPhams = sanPhamBUS.GetList();

                KhachHangBUS khachHangBUS = new KhachHangBUS();
                List<KhachHang> khachHangs = khachHangBUS.GetList();
                Console.Clear();
                Console.Write("Nhập mã hóa đơn muốn xem chi tiết: ");
                string ma = Console.ReadLine();
                Table table = new Table(150);//Khởi tạo bảng có chiều rộng = 150
                table.PrintLine();
                table.HienThiHang("Mã sản phẩm", "Tên sản phẩm", "Số lượng mua", "Thành tiền");
                table.PrintLine();
                foreach (var hd in hoadon)//Duyệt các phần tử trong danh sách hóa đơn
                {
                    foreach (var cthd in cthoaDons)
                    {
                        if (cthd.MaHD == ma)
                        {
                            foreach (var sp in sanPhams)
                            {
                                if (sp.MaSP == cthd.MaSP)
                                {
                                    kt++;
                                    table.HienThiHang(cthd.MaSP, sp.TenSP, cthd.SoLg.ToString(), cthd.Tien.ToString());
                                    table.PrintLine();                                    
                                }
                            }                            
                        }
                    }
                    break;
                }
                if (kt == 0)//Nếu kt=0
                {
                    Console.Clear();
                    Console.WriteLine("Không tìm thấy!");//Hiển thị ra màn hình
                }
                Console.WriteLine("Bạn có muốn hiển thị tiếp không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }
            }
        }
        public void Statistic()
        {
            List<HoaDon> tongHoaDons = hoaDonBUS.GetList();

            ChiTietHoaDonBUS cthoaDonBUS = new ChiTietHoaDonBUS();
            List<ChiTietHoaDon> cthoaDons = cthoaDonBUS.GetList();

            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            List<SanPham> sanPhams = sanPhamBUS.GetList();

            KhachHangBUS khachHangBUS = new KhachHangBUS();
            List<KhachHang> khachHangs = khachHangBUS.GetList();
            int kt = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write("Nhập ngày muốn thống kê: ");
                DateTime time = DateTime.Parse(Console.ReadLine());//Nhập từ khóa
                Table table = new Table(150);//Khởi tạo bảng có chiều rộng = 150
                table.PrintLine();
                table.HienThiHang("Mã hóa đơn", "Mã khách hàng", "Số tiền cần thanh toán", "Ngày nhập", "Mã người bán hàng");
                table.PrintLine();

                foreach (var thd in tongHoaDons)
                {
                    if (thd.NgayNhap == time)//Thống kê với ngày được nhập từ bàn phím  
                    {
                        kt++;//Tăng biến kt(kiểm tra) lên 1 đơn vị
                        table.HienThiHang(thd.MaHoaDon, thd.MaKH, thd.TongTien.ToString(), thd.NgayNhap.ToString("MM/dd/yyyy"), thd.MaNBH);
                        table.PrintLine();
                    }                    
                }
                if (kt == 0)//Nếu kt=0
                {
                    Console.Clear();
                    Console.WriteLine("Không tìm thấy!");//Hiển thị ra màn hình
                }
                Console.WriteLine("Bạn có muốn tìm kiếm tiếp không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }
            }
        }
        public void Search()
        {
            List<HoaDon> tongHoaDons = hoaDonBUS.GetList();

            ChiTietHoaDonBUS cthoaDonBUS = new ChiTietHoaDonBUS();
            List<ChiTietHoaDon> cthoaDons = cthoaDonBUS.GetList();

            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            List<SanPham> sanPhams = sanPhamBUS.GetList();

            KhachHangBUS khachHangBUS = new KhachHangBUS();
            List<KhachHang> khachHangs = khachHangBUS.GetList();
            
            int kt = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write("Tìm kiếm với từ khóa: ");
                string key = Console.ReadLine();//Nhập từ khóa
                Table table = new Table(100);
                table.PrintLine();
                table.HienThiHang("Mã hóa đơn", "Mã khách hàng", "Số tiền cần thanh toán", "Ngày nhập", "Mã người bán hàng");
                table.PrintLine();
                foreach (var hd in tongHoaDons)
                {
                    if (hd.MaHoaDon.Contains(key) || hd.MaNBH.Contains(key))//Tìm kiếm với mã hóa đơn, mã người bán hàng
                    {
                        kt++;//Tăng biến kt(kiểm tra) lên 1 đơn vị
                        table.HienThiHang(hd.MaHoaDon, hd.MaKH, hd.TongTien.ToString(), hd.NgayNhap.ToString("MM/dd/yyyy"), hd.MaNBH);
                        table.PrintLine();
                    }
                }
                if (kt == 0)//Nếu kt=0
                {
                    Console.Clear();
                    Console.WriteLine("Không tìm thấy!");//Hiển thị ra màn hình
                }
                Console.WriteLine("Bạn có muốn tìm kiếm tiếp không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }
            }
        }
        public string MaHD1()
        {
            while (true)
            {
                Console.Write("Mã hóa đơn: ");
                string maHD = Console.ReadLine();//Nhập mã hóa đơn
                if (maHD.Length == 6)//Nếu mã hóa đơn có độ dài = 6
                {
                    if (hoaDonBUS.GetIndex(maHD) < 0)//Nếu kết quả trả về chỉ số của mã hóa đơn < 0
                        return maHD;//trả về kết quả là mã hóa đơn vừa nhập
                    else Console.WriteLine("Mã hóa đơn đã tồn tại!");//Ngược lại, hiển thị thông báo ra màn hình
                }
                else Console.WriteLine("Mã hóa đơn gồm 6 kí tự là các chữ cái và các chữ số.");//Mã hóa đơn có độ dài khác 6 thì hiển thị thông báo ra màn hình
            }
        }
        public string MaHD2()
        {
            while (true)
            {
                Console.Write("Mã hóa đơn: ");
                string maHD = Console.ReadLine();
                if (maHD.Length == 6)
                {
                    if (hoaDonBUS.GetIndex(maHD) >= 0)//Nếu kết quả trả về chỉ số của mã hóa đơn >= 0
                        return maHD;
                    else Console.WriteLine("Mã hóa đơn không tồn tại!");
                }
                else Console.WriteLine("Mã hóa đơn gồm 6 kí tự là các chữ cái và các chữ số.");
            }
        }
        public string MaNBH()
        {
            NguoiBanHangBUS ngbanhangBUS = new NguoiBanHangBUS();
            while (true)
            {
                Console.Write("Mã người bán hàng: ");
                string maNBH = Console.ReadLine();
                if (maNBH.Length == 6)
                {
                    if (ngbanhangBUS.GetIndex(maNBH) >= 0)
                        return maNBH;
                    else Console.WriteLine("Mã người bán hàng không tồn tại!");
                }
                else Console.WriteLine("Mã người bán hàng gồm 6 kí tự là các chữ cái và các chữ số.");
            }
        }

        public DateTime NgayNhap()
        {
            while (true)
            {
                Console.Write("Ngày nhập: ");
                string ngayNhap = Console.ReadLine();
                DateTime today = DateTime.Today;//Lấy về ngày hiện tại
                try
                {
                    DateTime NgayNhap = DateTime.Parse(ngayNhap);
                    if (NgayNhap > today)//Nếu ngày nhập sau ngày hiện tại
                    {
                        Console.WriteLine("Ngày nhập không hợp lệ (Ngày nhập phải trước hoặc bằng ngày hiện tại)");//Hiển thị thông báo
                    }
                    else return NgayNhap;
                }
                catch
                {
                    Console.WriteLine("Bạn nhập sai định dạng ngày tháng (định dạng: MM/dd/yyyy)");
                }
            }
        }
        //Nhập mã sản phẩm
        public string MaSP(SanPhamBUS sanPhamBUS)
        {           
            while (true)
            {
                Console.Write("Mã sản phẩm: ");
                string maSP = Console.ReadLine();
                if (maSP.Length == 6)
                {
                    if (sanPhamBUS.GetIndex(maSP) >= 0)
                        return maSP;
                    else Console.WriteLine("Mã sản phẩm không tồn tại!");
                }
                else Console.WriteLine("Mã sản phẩm gồm 6 kí tự là các chữ số.");
            }
        }
        //Nhập số lượng
        public int SLuong()
        {
            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            List<SanPham> sanPhams = sanPhamBUS.GetList();
            while (true)
            {
                Console.Write("Số lượng: ");
                int sLuong = int.Parse(Console.ReadLine());
                foreach (var sp in sanPhams)
                {
                    if (sLuong <= 0 || sLuong > sp.SoLuong)//Nếu số lượng nhập <= 0 hoặc số lượng nhập vào lớn hơn trong kho
                    {
                        Console.WriteLine("Số lượng không hợp lệ!");
                    }
                    else return sLuong;
                }
            }
        }

        public string GetMaKH(KhachHangUI khachHangUI, KhachHangBUS khachHangBUS)
        {            
            while (true)
            {
                Console.Write("Mã khách hàng: ");
                string maKH = Console.ReadLine();
                if (khachHangBUS.GetIndex(maKH) < 0)
                {
                    string ten = khachHangUI.TenKH();
                    string sdt = khachHangUI.Sdt();
                    string email = khachHangUI.Email();
                    khachHangBUS.Add(new KhachHang(maKH, ten, sdt, email));
                    return maKH;
                }
                else return maKH;
            }
        }
    }
}
