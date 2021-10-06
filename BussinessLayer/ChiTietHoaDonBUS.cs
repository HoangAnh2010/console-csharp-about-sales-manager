using CTBHChoShopMyPham.BussinessLayer.Interface;
using CTBHChoShopMyPham.DataAcessLayer;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.BussinessLayer
{
    class ChiTietHoaDonBUS : ICRUD<ChiTietHoaDon>
    {
        DataAcessLayer.Interface.ICRUD<ChiTietHoaDon> CRUD = new ChiTietHoaDonDAL();

        public void Add(ChiTietHoaDon obj)
        {
           
            CRUD.Add(obj); 

        }

        public double TinhTien(string maSP, int soLuong, List<SanPham> sanPhams, SanPhamBUS sanPhamBUS)
        {
            int index = sanPhamBUS.GetIndex(x => x.MaSP == maSP, sanPhams);
            sanPhams[index].SoLuong -= soLuong;
            sanPhamBUS.Update(sanPhams[index].MaSP, sanPhams[index]);// update cho list sanPhams            
            return sanPhams[index].GiaBan * soLuong;
        }

        public void Delete(string ma)
        {
            KhachHangBUS khhangBUS = new KhachHangBUS();
            
            CRUD.Delete(ma);
        }

        public int GetIndex(string ma)
        {
            return CRUD.GetIndex(ma);
        }

        public List<ChiTietHoaDon> GetList()
        {
            return CRUD.GetList();
        }

        public void SaveAll(List<ChiTietHoaDon> listObj)
        {
            CRUD.SaveAll(listObj);
        }

        public void Update(string ma, ChiTietHoaDon newInfo)
        {
            CRUD.Update(ma, newInfo);
        }
    }
}
