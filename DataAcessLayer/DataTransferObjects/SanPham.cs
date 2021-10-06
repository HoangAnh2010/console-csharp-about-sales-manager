using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects
{
    class SanPham
    {
        //Phạm vi truy cập và các thành phần của lớp
        private string maSP;
        private string tenSP;
        private string maLoai;
        private int giaBan;
        private DateTime nsx;
        private DateTime hsd;
        private int soLuong;
        //Phương thức khởi tạo không tham số
        public SanPham()
        {

        }
        //Phương thức thiết lập
        public SanPham(string maSP, string tenSP, string maLoai, int giaBan, DateTime nsx, DateTime hsd, int soLuong)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.maLoai = maLoai;
            this.giaBan = giaBan;
            this.nsx = nsx;
            this.hsd = hsd;
            this.soLuong = soLuong;
        }
        //Phương thức lấy và thiết lập dữ liệu  các thành phần của lớp
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string MaLoai { get => maLoai; set => maLoai = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public DateTime Nsx { get => nsx; set => nsx = value; }
        public DateTime Hsd { get => hsd; set => hsd = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        //Phương thức hiển thị thông tin dưới dạng chuỗi
        public override string ToString()
        {
            return maSP + "#" + tenSP + "#" + maLoai + "#" + giaBan + "#" + nsx.ToString("MM/dd/yyyy") + "#" + hsd.ToString("MM/dd/yyyy") + "#" + soLuong;
        }
    }
}
