using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects
{
    class ChiTietHoaDon
    {
        //Phạm vi truy cập và các thành phần của lớp
        private string maHD;        
        private string maSP; 
        private int soLg;
        private double tien;        
        
        //Phương thức khởi tạo không tham số
        public ChiTietHoaDon()
        {

        }
        //Phương thức thiết lập

        public ChiTietHoaDon(string maHD, string maSP, int soLg, double tien)
        {
            this.maHD = maHD;
                    
            this.maSP = maSP;
            this.soLg = soLg;
            this.tien = tien;
        }
        //Phương thức lấy và thiết lập dữ liệu  các thành phần của lớp
        public string MaHD { get => maHD; set => maHD = value; }
        
        public string MaSP { get => maSP; set => maSP = value; }
        public int SoLg { get => soLg; set => soLg = value; }
        public double Tien { get => tien; set => tien = value; }
        //Phương thức hiển thị thông tin dưới dạng chuỗi
        public override string ToString()
        {
            return maHD + "#" + maSP + "#" + soLg + "#" + tien;
        }
    }
}
