using CTBHChoShopMyPham.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham
{
    class Menu
    {
        private string tieuDe;
        private string[] cacChucNang;

        public Menu(string tieuDe, string[] cacChucNang)
        {
            this.tieuDe = tieuDe;
            this.cacChucNang = cacChucNang;
        }
        public int Chon()
        {
            Console.Clear();
            int vtri = 0;
            PrintMenu(vtri);
            int cursorPos = Console.CursorLeft;
            while (true)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (vtri < this.cacChucNang.Length - 1)
                        {
                            vtri++;
                            PrintMenu(vtri);
                        }
                        Console.CursorLeft = cursorPos;
                        break;
                    case ConsoleKey.UpArrow:
                        if (vtri > 0)
                        {
                            vtri--;
                            PrintMenu(vtri);
                        }
                        Console.CursorLeft = cursorPos;
                        break;
                    case ConsoleKey.Enter:
                        return vtri;
                }
            }
            return 0;
        }
        public void PrintMenu(int vtri)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\n\n\n\n\n\n");
            Console.CursorLeft = Console.WindowWidth/2;
            Console.WriteLine(this.tieuDe);
            
            for (int i = 0; i < this.cacChucNang.Length; i++)
            {
                Console.CursorLeft = ((Console.WindowWidth - this.tieuDe.Length) / 2)-5;
                if (vtri == i )
                {                    
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(this.cacChucNang[i]);                    
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(this.cacChucNang[i]);
            }
            Console.CursorLeft = (Console.WindowWidth ) / 2;
            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\tBạn đang chọn chế độ: " + (vtri + 1));
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();            
            Console.WriteLine("\n\n\n\n\n");            
            while (true)
            {                
                Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ╔═════════════════════════════════════════════════════════════════════╗"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                 CHƯƠNG TRÌNH BÁN HÀNG CHO SHOP MỸ PHẨM              ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                   ----------------||-----------------               ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ║                                                                     ║"); Console.CursorLeft = Console.WindowWidth / 3;
                Console.WriteLine(" ╚═════════════════════════════════════════════════════════════════════╝");
                break;                
            }
            Console.ReadKey();
            string[] menu = {
                "1. Các chức năng về loại sản phẩm.",
                "2. Các chức năng về sản phẩm.",
                "3. Các chức năng về người bán hàng.",
                "4. Các chức năng về hóa đơn.",
                "5. Các chức năng về khách hàng.",
                "6. Thoát."
            };
            Menu Menu = new Menu("\n\n\n\n\n" + "\t\t\t\t\t\t\t\t\t\t\t\t" + "MENU CHÍNH" +"\n\n" ,  menu);
            bool exit = false;
            while (!exit)
            {
                switch (Menu.Chon())
                {
                    case 0:
                        LoaiSanPhamUI loaispUI = new LoaiSanPhamUI();
                        loaispUI.Menu();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 1:
                        SanPhamUI spUI = new SanPhamUI();
                        spUI.Menu();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        NguoiBanHangUI ngbanhangUI = new NguoiBanHangUI();
                        ngbanhangUI.Menu();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        HoaDonUI hdUI = new HoaDonUI();
                        hdUI.Menu();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        KhachHangUI khachhangUI = new KhachHangUI();
                        khachhangUI.Menu();
                        Console.ReadKey();
                        Console.Clear();
                        break;                    
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }            
        }
    }
}
