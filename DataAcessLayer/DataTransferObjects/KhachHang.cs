using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects
{
    class KhachHang
    {
        //Phạm vi truy cập và các thành phần của lớp
        private string maKH;
        private string tenKH;
        private string sdt;
        private string email;
       
        //Phương thức khởi tạo không tham số
        public KhachHang()
        {

        }
        //Phương thức thiết lập
        public KhachHang(string maKH, string tenKH, string sdt, string email)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.sdt = sdt;
            this.email = email;
            
        }
        //Phương thức lấy và thiết lập dữ liệu  các thành phần của lớp
        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        
        //Phương thức hiển thị thông tin dưới dạng chuỗi
        public override string ToString()
        {
            return maKH + "#" + tenKH + "#" + sdt + "#" + email;
        }
    }
}
