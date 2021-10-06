using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects
{
    class LoaiSanPham
    {
        //Phạm vi truy cập và các thành phần của lớp
        private string maLoai;
        private string tenLoai;
        private string tenTH;
        //Phương thức khởi tạo không tham số
        public LoaiSanPham()
        {

        }
        //Phương thức thiết lập
        public LoaiSanPham(string maLoai, string tenLoai, string tenTH)
        {
            this.maLoai = maLoai;
            this.tenLoai = tenLoai;
            this.tenTH = tenTH;
        }
        //Phương thức lấy và thiết lập dữ liệu  các thành phần của lớp
        public string MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TenTH { get => tenTH; set => tenTH = value; }
        //Phương thức hiển thị thông tin dưới dạng chuỗi
        public override string ToString()
        {
            return maLoai + "#" + tenLoai + "#" + tenTH;
        }
    }
}
