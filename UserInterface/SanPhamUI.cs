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
    class SanPhamUI
    {
        SanPhamBUS sanphamBUS = new SanPhamBUS();
        public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] menu = {
                "1. Thêm sản phẩm.",
                "2. Sửa thông tin sản phẩm.",
                "3. Xóa sản phẩm.",
                "4. Hiển thị danh sách các sản phẩm.",
                "5. Thống kê số lượng các sản phẩm.",
                "6. Tìm kiếm sản phẩm.",
                "7. Quay lại trang chủ."
            };
            MenuSelector menuSelector = new MenuSelector("\n\n\n\n\n"  + "\t\t\t\t\t\t\t\t\t\t" + "CÁC CHỨC NĂNG VỀ SẢN PHẨM" +"\n\n", menu);
            bool exit = false;
            while(!exit)
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
                        Statistic();
                        Console.Clear();
                        break;
                    case 5:
                        Search();
                        Console.Clear();
                        break;
                    case 6:
                        exit = true;
                        break;
                }
            }
            
        }
        //Thêm sản phẩm
        public void Add()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                string maSP = MaSP1();
                string tenSP = TenSP();
                string maLoai = MaLoai();
                int gia = GiaBan();
                DateTime nsx = NSX();
                DateTime hsd = HSD();
                if (nsx >= hsd)//Nếu nsx sau hoặc bằng hsd
                {
                    Console.WriteLine("Hạn sử dụng không hợp lệ (HSD phải sau NSX)");
                    hsd = HSD();//Nhập lại hsd                    
                }                                    
                int soLuong = SoLuong();
                sanphamBUS.Add(new SanPham(maSP, tenSP, maLoai, gia, nsx, hsd, soLuong));
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
        //Sửa thông tin sản phẩm
        public void Update()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                string maSP = MaSP2();
                string tenSP = TenSP();
                string maLoai = MaLoai();
                int gia = GiaBan();
                DateTime nsx = NSX();
                DateTime hsd = HSD();
                if (nsx >= hsd)
                {
                    Console.WriteLine("Hạn sử dụng không hợp lệ (HSD phải sau NSX)");
                    hsd = HSD();
                }
                int soLuong = SoLuong();
                sanphamBUS.Update(maSP, new SanPham(maSP, tenSP, maLoai, gia, nsx, hsd, soLuong));
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
        //Xóa sản phẩm
        public void Delete()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maSP = MaSP2();
                sanphamBUS.Delete(maSP);
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
        //Hiển thị danh sách sản phẩm
        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                List<SanPham> sanpham = sanphamBUS.GetList();
                Table table = new Table(180);//tạo bảng có độ rộng = 180
                table.PrintLine();
                table.HienThiHang("Mã sản phẩm", "Tên sản phẩm", "Mã loại", "Giá", "NSX", "HSD", "Số lượng");
                table.PrintLine();
                foreach (var sp in sanpham)//Duyệt các phần tử trong danh sách sản phẩm
                {          
                    table.HienThiHang(sp.MaSP, sp.TenSP, sp.MaLoai, sp.GiaBan.ToString(), sp.Nsx.ToString("MM/dd/yyyy"), sp.Hsd.ToString("MM/dd/yyyy"), sp.SoLuong.ToString());
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
        //Tìm kiếm sản phẩm
        public void Search()
        {            
            bool exit = false;
            while (!exit)
            {
                List<SanPham> sanpham = sanphamBUS.GetList();
                int kt = 0;
                Console.Clear();
                Console.Write("Tìm kiếm với từ khóa: ");
                string key = Console.ReadLine();
                Table table = new Table(180);
                table.PrintLine();
                table.HienThiHang("Mã sản phẩm", "Tên sản phẩm", "Mã loại", "Giá", "NSX", "HSD", "Số lượng");
                table.PrintLine();
                foreach (var sp in sanpham)
                {
                    if (sp.MaSP.Contains(key) || sp.TenSP.Contains(key) || sp.MaLoai.Contains(key))//Tìm kiếm theo mã sản phẩm, tên sản phẩm, mã loại
                    {
                        kt++;                                                
                        table.HienThiHang(sp.MaSP,sp.TenSP,sp.MaLoai,sp.GiaBan.ToString(),sp.Nsx.ToString("MM/dd/yyyy"),sp.Hsd.ToString("MM/dd/yyyy"),sp.SoLuong.ToString());
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
        //Thống kê
        public void Statistic()
        {
            List<SanPham> sanpham = sanphamBUS.GetList();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Table table = new Table(100);
                table.PrintLine();
                table.HienThiHang("Mã sản phẩm", "Tên sản phẩm","Số lượng");
                table.PrintLine();
                foreach (var sp in sanpham)
                {
                    table.HienThiHang(sp.MaSP, sp.TenSP, sp.SoLuong.ToString());
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
        //Nhập mã sản phẩm chưa tồn tại
        public string MaSP1()
        {
            while(true)
            {
                Console.Write("Mã sản phẩm: ");
                string maSP = Console.ReadLine();
                if (maSP.Length == 6)
                {
                    if (sanphamBUS.GetIndex(maSP) < 0)
                        return maSP;
                    else Console.WriteLine("Mã sản phẩm đã tồn tại!");
                }
                else Console.WriteLine("Mã sản phẩm gồm 6 kí tự là các chữ cái và các chữ số.");
            }
        }
        //Nhập mã sản phẩm đã tồn tại
        public string MaSP2()
        {
            while (true)
            {
                Console.Write("Mã sản phẩm: ");
                string maSP = Console.ReadLine();
                if (maSP.Length == 6)
                {
                    if (sanphamBUS.GetIndex(maSP) >= 0)
                        return maSP;
                    else Console.WriteLine("Mã sản phẩm không tồn tại!");
                }
                else Console.WriteLine("Mã sản phẩm gồm 6 kí tự là các chữ cái và các chữ số.");
            }
        }
        //Nhập tên sản phẩm
        public string TenSP()
        {
            while(true)
            {
                Console.Write("Tên sản phẩm: ");
                string tenSP = Console.ReadLine();
                if(tenSP.Length!=0)//Nếu độ dài tên khác 0
                {
                    return tenSP;
                }
                else Console.WriteLine("Tên sản phẩm phải khác rỗng!");
            }
        }
        //Nhập mã loại
        public string MaLoai()
        {
            LoaiSanPhamBUS loaispBUS = new LoaiSanPhamBUS();
            while(true)
            {
                Console.Write("Mã loại sản phẩm: ");
                string maLoai = Console.ReadLine();
                if(maLoai.Length==6)
                {
                    if (loaispBUS.GetIndex(maLoai) >= 0)
                        return maLoai;
                    else Console.WriteLine("Mã loại sản phẩm không tồn tại!");
                }
                else Console.WriteLine("Mã loại sản phẩm gồm 6 kí tự");
            }
        }
        //Nhập giá bán
        public int GiaBan()
        {
            while (true)
            {
                Console.Write("Giá bán (là một số lớn hơn 1000): ");
                int gia = int.Parse(Console.ReadLine());
                if(gia<1000)//Nếu giá bán <1000
                {
                    Console.WriteLine("Giá bán không hợp lệ!");
                }
                else return gia;
            }
        }
        //Nhập nsx
        public DateTime NSX()
        {
            while (true)
            {
                Console.Write("Ngày sản xuất: ");
                string nsx = Console.ReadLine();
                DateTime today = DateTime.Today;//Lấy về ngày hiện tại             
                try
                {
                    DateTime Nsx = DateTime.Parse(nsx);
                                       
                    if (Nsx>today)//Nếu nsx sau ngày hiện tại
                    {
                        Console.WriteLine("Ngày sản xuất không hợp lệ (NSX phải trước hoặc bằng ngày hiện tại)");
                    }
                    else return Nsx;
                }
                catch 
                {
                    Console.WriteLine("Bạn nhập sai định dạng ngày tháng (định dạng: MM/dd/yyyy)");
                }                
            }
        }
        //Nhập hsd
        public DateTime HSD()
        {            
            while (true)
            {
                Console.Write("Hạn sử dụng: ");
                string hsd = Console.ReadLine();
                try
                {                    
                    DateTime Hsd = DateTime.Parse(hsd);                    
                    return Hsd;                    
                }
                catch 
                {
                    Console.WriteLine("Bạn nhập sai định dạng ngày tháng (định dạng: MM/dd/yyyy)");
                }                
            }
        }
        //Nhập số lượng
        public int SoLuong()
        {
            while (true)
            {
                Console.Write("Số lượng: ");
                int soLuong = int.Parse(Console.ReadLine());
                if (soLuong < 0)//Nếu số lượng < 0
                {
                    Console.WriteLine("Số lượng không hợp lệ!");
                }
                else return soLuong;
            }
        }
    }
}
