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
    class LoaiSanPhamUI
    {
        LoaiSanPhamBUS loaispBUS = new LoaiSanPhamBUS();
        public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] menu = {
                "1. Thêm loại sản phẩm.",
                "2. Sửa thông tin loại sản phẩm.",
                "3. Xóa loại sản phẩm.",
                "4. Hiển thị danh sách các loại sản phẩm.",
                "5. Tìm kiếm loại sản phẩm.",
                "6. Quay lại trang chủ."
            };
            MenuSelector menuSelector = new MenuSelector("\n\n\n\n\n" + "\t\t\t\t\t\t\t\t\t\t" + "CÁC CHỨC NĂNG VỀ LOẠI SẢN PHẨM"+"\n\n", menu);
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
        //Thêm loại sản phẩm
        public void Add()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maLoai = MaLoai1();
                string tenLoai = TenLoai();
                string tenTH = TenThuongHieu();
                
                loaispBUS.Add(new LoaiSanPham(maLoai, tenLoai, tenTH));
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
        //Sửa loại sản phẩm
        public void Update()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maLoai = MaLoai2();
                string tenLoai = TenLoai();
                string tenTH = TenThuongHieu();

                loaispBUS.Update(maLoai,new LoaiSanPham(maLoai, tenLoai, tenTH));

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
        //Xóa loại sản phẩm
        public void Delete()
        {
            Console.CursorVisible = true;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                string maLoai = MaLoai2();
                loaispBUS.Delete(maLoai);
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
        //Hiển thị danh sách loại sản phẩm
        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                List<LoaiSanPham> loaisanpham = loaispBUS.GetList();
                Table table = new Table(70);//tạo bảng có độ rộng = 70
                table.PrintLine();
                table.HienThiHang("Mã loại", "Tên loại", "Tên thương hiệu");
                table.PrintLine();
                foreach (var loaisp in loaisanpham)//Duyệt các phần tử trong danh sách 
                {
                    table.HienThiHang(loaisp.MaLoai,loaisp.TenLoai,loaisp.TenTH);
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
        //Tìm kiếm loại sản phẩm
        public void Search()
        {
            List<LoaiSanPham> loaisanpham = loaispBUS.GetList();
            int kt = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write("Tìm kiếm với từ khóa: ");
                string key = Console.ReadLine();
                Table table = new Table(70);//tạo bảng có độ rộng = 70
                table.PrintLine();
                table.HienThiHang("Mã loại", "Tên loại", "Tên thương hiệu");
                table.PrintLine();
                foreach (var loaisp in loaisanpham)
                {
                    if (loaisp.MaLoai.Contains(key) || loaisp.TenLoai.Contains(key) || loaisp.TenTH.Contains(key))//Tìm kiếm với mã loại, tên loại, tên thương hiệu
                    {
                        kt++;
                        table.HienThiHang(loaisp.MaLoai, loaisp.TenLoai, loaisp.TenTH);
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
        //Nhập mã loại chưa tồn tại
        public string MaLoai1()
        {
            while (true)
            {
                Console.Write("Mã loại sản phẩm: ");
                string maLoai = Console.ReadLine();
                if (maLoai.Length == 6)
                {
                    if (loaispBUS.GetIndex(maLoai) < 0)
                        return maLoai;
                    else Console.WriteLine("Mã loại sản phẩm đã tồn tại!");
                }
                else Console.WriteLine("Mã loại sản phẩm gồm 6 kí tự là các chữ cái và các chữ số.");
            }
        }
        //Nhập mã loại đã tồn tại
        public string MaLoai2()
        {
            while (true)
            {
                Console.Write("Mã loại sản phẩm: ");
                string maLoai = Console.ReadLine();
                if (maLoai.Length == 6)
                {
                    if (loaispBUS.GetIndex(maLoai) >= 0)
                        return maLoai;
                    else Console.WriteLine("Mã loại sản phẩm không tồn tại!");
                }
                else Console.WriteLine("Mã loại sản phẩm gồm 10 kí tự là các chữ cái và các chữ số.");
            }
        }
        //Nhập tên loại
        public string TenLoai()
        {
            while (true)
            {
                Console.Write("Tên loại sản phẩm: ");
                string tenLoai = Console.ReadLine();
                if (tenLoai.Length != 0)
                    return tenLoai;
                else Console.WriteLine("Tên phải khác rỗng!");
                
            }
        }
        //Nhập tên thương hiệu
        public string TenThuongHieu()
        {
            while (true)
            {
                Console.Write("Tên thương hiệu: ");
                string tenTH = Console.ReadLine();
                if (tenTH.Length != 0)
                    return tenTH;
                else Console.WriteLine("Tên phải khác rỗng!");
            }
        }
        
    }
}
