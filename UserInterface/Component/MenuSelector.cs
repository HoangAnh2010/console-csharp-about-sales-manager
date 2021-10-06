using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.UserInterface.Component
{
    class MenuSelector
    {
        private string tieuDe;
        private string[] cacChucNang;

        public MenuSelector(string tieuDe, string[] cacChucNang)
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
            while(true)
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
                        if (vtri >0)
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
            Console.WriteLine(this.tieuDe);
            Console.CursorLeft = (Console.WindowWidth - this.tieuDe.Length) / 2;
            for (int i=0; i< this.cacChucNang.Length; i++)
            {
                Console.CursorLeft = ((Console.WindowWidth - this.tieuDe.Length) / 2) - 5;
                if (vtri==i)
                {                    
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(this.cacChucNang[i]);                    
                    Console.ResetColor();                                    
                }
                else
                    Console.WriteLine(this.cacChucNang[i]);
            }
            Console.CursorLeft = (Console.WindowWidth) / 2;
            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\tBạn đang chọn chế độ: " + (vtri + 1));
        }
    }
}
