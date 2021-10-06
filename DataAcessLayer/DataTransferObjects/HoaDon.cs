using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects
{
    class HoaDon
    {
        private string maHoaDon;
        private string maKH;
        private double tongTien;
        private DateTime ngayNhap;
        private string maNBH;

        public HoaDon()
        {

        }

        public HoaDon(string maHoaDon, string maKH, double tongTien, DateTime ngayNhap, string maNBH)
        {
            this.maHoaDon = maHoaDon;
            this.maKH = maKH;
            this.tongTien = tongTien;
            this.ngayNhap = ngayNhap;
            this.maNBH = maNBH;
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string MaNBH { get => maNBH; set => maNBH = value; }

        public override string ToString()
        {
            return maHoaDon + "#" + maKH + "#" + tongTien + "#" + ngayNhap.ToString("MM/dd/yyyy") + "#" + maNBH;
        }
    }
}
