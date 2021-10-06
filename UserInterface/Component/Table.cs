using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.UserInterface.Component
{
    class Table
    {
        private int crong;
        public Table(int crong)
        {
            this.crong = crong;
        }
        public void PrintLine()
        {
            Console.WriteLine(new string('-', crong-3));//Hiển thị chuỗi chứa kí tự '-' có số lần lặp = crong -3
        }
        public string NoiDung(string ndung, int cdcot)
        {
            ndung = ndung.Length > cdcot ? ndung.Substring(0, cdcot - 3) + "..." : ndung;
            //Nếu độ dài ndung >cdcot thì hiện độ dài ndung-3 và thêm 3 dấu chấm vào cuối, ngược lại thì hiện ndung đầy đủ 
            if(string.IsNullOrEmpty(ndung))//Nếu ndung rỗng
            {
                return new string(' ', crong);//Trả về chuỗi chứa kí tự cách có số lần lặp = crong
            }
            else
            {
                return ndung.PadRight(cdcot - (cdcot - ndung.Length) / 2).PadLeft(cdcot);
                //Trả về ndung được căn giữa
            }
        }
        public void HienThiHang(params string[] cot)
        {
            int cdcot = (crong - cot.Length) / cot.Length;
            string hang = "|";
            foreach(var c in cot)
            {
                hang += NoiDung(c, cdcot) + "|";
            }
            Console.WriteLine(hang);
        }
    }
}
