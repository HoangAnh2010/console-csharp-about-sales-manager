using CTBHChoShopMyPham.BussinessLayer;
using CTBHChoShopMyPham.UserInterface.Component;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.UserInterface
{
    class KhachHangUI
    {
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] menu = {
                "1. Thêm khách hàng.",
                "2. Sửa thông tin khách hàng.",
                "3. Xóa khách hàng.",
                "4. Hiển thị danh sách khách hàng.",
                "5. Tìm kiếm khách hàng.",
                "6. Quay lại trang chủ."
            };
            MenuSelector menuSelector = new MenuSelector("\n\n\n\n\n" + "\t\t\t\t\t\t\t\t\t\t" + "CÁC CHỨC NĂNG VỀ KHÁCH HÀNG"+"\n\n", menu);
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
                        Search();
                        Console.Clear();
                        break;
                    case 5:
                        exit = true;
                        break;
                }
            }

        }
        //Thêm khách hàng
        public void Add()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maKH = MaKH1();
                string tenKH = TenKH();
                string sdt = Sdt();
                string email = Email();                  
                khachHangBUS.Add(new KhachHang(maKH, tenKH, sdt, email));
                Console.WriteLine("Thêm thành công!");
                Console.WriteLine("Bạn có muốn nhập tiếp không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }
            }

        }
        //Sửa thông tin khách hàng
        public void Update()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maKH = MaKH2();
                string tenKH = TenKH();
                string sdt = Sdt();
                string email = Email();
               
                khachHangBUS.Update(maKH, new KhachHang(maKH, tenKH, sdt, email));
                Console.WriteLine("Sửa thành công!");
                Console.WriteLine("Bạn có muốn sửa tiếp không? (Nhấn Enter để tiếp tục/Nhấn esc để thoát)");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    exit = true;
                }
            }
        }
        //Xóa khách hàng
        public void Delete()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maKH = MaKH2();
                khachHangBUS.Delete(maKH);
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
        //Hiển thị danh sách khách hàng
        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                List<KhachHang> khachhang = khachHangBUS.GetList();
                Table table = new Table(90);//tạo bảng có độ rộng = 90
                table.PrintLine();
                table.HienThiHang("Mã khách hàng", "Tên khách hàng", "Số điện thoại", "Email", "Mã hóa đơn");
                table.PrintLine();
                foreach (var khg in khachhang)//Duyệt các phần tử trong danh sách 
                {
                    table.HienThiHang(khg.MaKH,khg.TenKH,khg.Sdt,khg.Email);
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
        //Tìm kiếm thông tin khách hàng
        public void Search()
        {
            List<KhachHang> khhang = khachHangBUS.GetList();
            int kt = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write("Tìm kiếm với từ khóa: ");
                string key = Console.ReadLine();
                Table table = new Table(90);//tạo bảng có độ rộng = 90
                table.PrintLine();
                table.HienThiHang("Mã khách hàng", "Tên khách hàng", "Số điện thoại", "Email", "Mã hóa đơn");
                table.PrintLine();
                foreach (var khg in khhang)
                {
                    if (khg.MaKH.Contains(key) || khg.TenKH.Contains(key)  || khg.Sdt.Contains(key))//Tìm kiếm với mã khg, tên khg, mã hóa đơn, số điện thoại
                    {
                        kt++;
                        table.HienThiHang(khg.MaKH, khg.TenKH, khg.Sdt, khg.Email);
                        table.PrintLine();
                    }
                }
                if (kt == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Không tìm thấy!");
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
        //Nhập mã khách hàng chưa tồn tại
        public string MaKH1()
        {
            while (true)
            {
                Console.Write("Mã khách hàng: ");
                string maKH = Console.ReadLine();
                if (maKH.Length == 6)
                {
                    if (khachHangBUS.GetIndex(maKH) < 0)
                        return maKH;
                    else Console.WriteLine("Mã khách hàng đã tồn tại!");
                }
                else Console.WriteLine("Mã khách hàng gồm 6 kí tự là các chữ số.");
            }
        }
        //Nhập mã khách hàng đã tồn tại
        public string MaKH2()
        {
            while (true)
            {
                Console.Write("Mã khách hàng: ");
                string maKH = Console.ReadLine();
                if (maKH.Length == 6)
                {
                    if (khachHangBUS.GetIndex(maKH) >= 0)
                        return maKH;
                    else Console.WriteLine("Mã khách hàng không tồn tại!");
                }
                else Console.WriteLine("Mã khách hàng gồm 6 kí tự là các chữ số.");
            }
        }
        //Nhập tên khách hàng
        public string TenKH()
        {
            while (true)
            {
                Console.Write("Tên khách hàng: ");
                string tenKH = Console.ReadLine();
                if (tenKH.Length != 0)
                    return tenKH;
                else Console.WriteLine("Tên phải khác rỗng!");                
            }
        }
        //Nhập số điện thoại
        public string Sdt()
        {
            while (true)
            {
                Console.Write("Số điện thoại khách hàng: ");
                string sdt = Console.ReadLine();
                if (sdt.Length == 10)
                {
                    if (khachHangBUS.GetIndex(sdt) < 0)
                        return sdt;
                    else Console.WriteLine("Số điện thoại khách hàng đã tồn tại hoặc không hợp lệ!");
                }
                else Console.WriteLine("Số điện thoại là các kí tự từ 0 - 9");
            }
        }
        //Nhập email của khách hàng
        public string Email()
        {
            while (true)
            {
                Console.Write("Email khách hàng: ");
                string email = Console.ReadLine();
                if (email.Length != 0)
                    return email;
                else Console.WriteLine("Email phải khác rỗng!");
                
            }
        }
        //Nhập mã hóa đơn 
        public string MaHD()
        {
            ChiTietHoaDonBUS hoaDonBUS = new ChiTietHoaDonBUS();
            while (true)
            {
                Console.Write("Mã hóa đơn: ");
                string maHD = Console.ReadLine();
                if (maHD.Length == 6)
                {
                    if (hoaDonBUS.GetIndex(maHD) >= 0)
                        return maHD;
                    else Console.WriteLine("Mã hóa đơn không tồn tại!");
                }
                else Console.WriteLine("Mã hóa đơn gồm 6 kí tự là các chữ cái và các chữ số.");
            }
        }
        
    }
}
