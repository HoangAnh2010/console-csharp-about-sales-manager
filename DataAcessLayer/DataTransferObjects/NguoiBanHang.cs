using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects
{
    class NguoiBanHang
    {
        //Phạm vi truy cập và các thành phần của lớp
        private string maNBH;
        private string tenNBH;
        private string sdt;
        private string email;
        private string dc;
        //Phương thức khởi tạo không tham số
        public NguoiBanHang()
        {

        }
        //Phương thức thiết lập
        public NguoiBanHang(string maNBH, string tenNBH, string sdt, string email, string dc)
        {
            this.maNBH = maNBH;
            this.tenNBH = tenNBH;
            this.sdt = sdt;
            this.email = email;
            this.dc = dc;
        }
        //Phương thức lấy và thiết lập dữ liệu  các thành phần của lớp
        public string MaNBH { get => maNBH; set => maNBH = value; }
        public string TenNBH { get => tenNBH; set => tenNBH = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string Dc { get => dc; set => dc = value; }
        //Phương thức hiển thị thông tin dưới dạng chuỗi
        public override string ToString()
        {
            return maNBH + "#" + tenNBH + "#" + sdt + "#" + email + "#" + dc;
        }
    }
}
