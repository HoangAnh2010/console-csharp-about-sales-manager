using CTBHChoShopMyPham.BussinessLayer;
using CTBHChoShopMyPham.UserInterface.Component;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Net.Http;
using System.IO;

namespace CTBHChoShopMyPham.UserInterface
{
    class NguoiBanHangUI
    {
        NguoiBanHangBUS ngbanhangBUS = new NguoiBanHangBUS();
        public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] menu = {
                "1. Thêm người bán hàng.",
                "2. Sửa thông tin người bán hàng.",
                "3. Xóa người bán hàng.",
                "4. Hiển thị danh sách người bán hàng.",
                "5. Tìm kiếm người bán hàng.",
                "6. Quay lại trang chủ."
            };
            MenuSelector menuSelector = new MenuSelector("\n\n\n\n\n" + "\t\t\t\t\t\t\t\t\t\t" + "CÁC CHỨC NĂNG VỀ NGƯỜI BÁN HÀNG"+"\n\n", menu);
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
        //Thêm người bán hàng
        public void Add()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maNBH = MaNBH1();
                string tenNBH = TenNBH();
                string sdt = Sdt();
                string email = Email();
                string dc = DiaChi();
                ngbanhangBUS.Add(new NguoiBanHang(maNBH, tenNBH, sdt,email,dc));
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
        //Sửa thông tin của người bán hàng
        public void Update()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maNBH = MaNBH2();
                string tenNBH = TenNBH();
                string sdt = Sdt();
                string email = Email();
                string dc = DiaChi();
                ngbanhangBUS.Update(maNBH,new NguoiBanHang(maNBH, tenNBH, sdt, email, dc));
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
        //Xóa người bán hàng
        public void Delete()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maNBH = MaNBH2();
                ngbanhangBUS.Delete(maNBH);
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
        //Hiển thị danh sách người bán hàng
        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                List<NguoiBanHang> ngbanhang = ngbanhangBUS.GetList();                
                Table table = new Table(190);//tạo bảng có độ rộng = 190
                table.PrintLine();
                table.HienThiHang("Mã người bán hàng", "Tên người bán hàng", "Số điện thoại", "Email", "Địa chỉ");
                table.PrintLine();
                foreach (var nbh in ngbanhang)//Duyệt các phần tử trong danh sách người bán hàng
                {
                    table.HienThiHang(nbh.MaNBH,nbh.TenNBH,nbh.Sdt,nbh.Email,nbh.Dc);
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
        //Tìm kiếm thông tin người bán hàng
        public void Search()
        {
            List<NguoiBanHang> ngban = ngbanhangBUS.GetList();
            int kt = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write("Tìm kiếm với từ khóa: ");
                string key = Console.ReadLine();
                Table table = new Table(190);//tạo bảng có độ rộng = 190
                table.PrintLine();
                table.HienThiHang("Mã người bán hàng", "Tên người bán hàng", "Số điện thoại", "Email", "Địa chỉ");
                table.PrintLine();
                foreach (var nbh in ngban)
                {
                    if (nbh.MaNBH.Contains(key) || nbh.TenNBH.Contains(key) || nbh.Sdt.Contains(key))//Tìm kiếm với mã ngbh,tên ngbh, số điện thoại ngbh
                    {
                        kt++;
                        table.HienThiHang(nbh.MaNBH, nbh.TenNBH, nbh.Sdt, nbh.Email, nbh.Dc);
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
        //Nhập mã ngbh chưa tồn tại
        public string MaNBH1()
        {
            while (true)
            {
                Console.Write("Mã người bán hàng: ");
                string maNBH = Console.ReadLine();
                if (maNBH.Length == 6)
                {
                    if (ngbanhangBUS.GetIndex(maNBH) < 0)
                        return maNBH;
                    else Console.WriteLine("Mã người bán hàng đã tồn tại!");
                }
                else Console.WriteLine("Mã người bán hàng gồm 6 kí tự là các chữ số.");
            }
        }
        //Nhập mã ngbh đã tồn tại
        public string MaNBH2()
        {
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
                else Console.WriteLine("Mã người bán hàng gồm 6 kí tự là các chữ số.");
            }
        }
        //Nhập tên ngbh
        public string TenNBH()
        {
            while (true)
            {
                Console.Write("Tên người bán hàng: ");
                string tenNBH = Console.ReadLine();
                if(tenNBH.Length!=0)
                    return tenNBH;
                else Console.WriteLine("Tên người bán hàng phải khác rỗng!");
            }
        }
        //Nhập số điện thoại
        public string Sdt()
        {
            while (true)
            {
                Console.Write("Số điện thoại người bán hàng: ");
                string sdt = Console.ReadLine();
                if (sdt.Length == 10)
                {
                    if (ngbanhangBUS.GetIndex(sdt) < 0)
                        return sdt;
                    else Console.WriteLine("Số điện thoại người bán hàng đã tồn tại hoặc không hợp lệ!");
                }
                else Console.WriteLine("Số điện thoại là các kí tự từ 0 - 9");
                                
            }
        }
        //Nhập email
        public string Email()
        {
            while (true)
            {
                Console.Write("Email người bán hàng: ");
                string email = Console.ReadLine();
                if (email.Length != 0)
                    return email;
                else Console.WriteLine("Email phải khác rỗng!");
                
            }
        }
        //Nhập địa chỉ của ngbh
        public string DiaChi()
        {
            while (true)
            {
                Console.Write("Địa chỉ của người bán hàng: ");
                string dc = Console.ReadLine();
                if (dc.Length != 0)
                    return dc;
                else Console.WriteLine("Địa chỉ phải khác rỗng!");
                
            }
        }
    }
}
