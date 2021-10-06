using CTBHChoShopMyPham.BussinessLayer.Interface;
using CTBHChoShopMyPham.DataAcessLayer;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.BussinessLayer
{
    class LoaiSanPhamBUS: ICRUD<LoaiSanPham>
    {
        
        DataAcessLayer.Interface.ICRUD<LoaiSanPham> CRUD = new LoaiSanPhamDAL();

        public void Add(LoaiSanPham obj)
        {
            CRUD.Add(obj);
        }

        public void Delete(string ma)
        {
            SanPhamBUS spBUS = new SanPhamBUS();
            spBUS.Delete(sanpham => sanpham.MaLoai == ma);
            CRUD.Delete(ma);
        }
        public int GetIndex(string ma)
        {
            return CRUD.GetIndex(ma);
        }

        public List<LoaiSanPham> GetList()
        {
            return CRUD.GetList();
        }

        public void SaveAll(List<LoaiSanPham> listObj)
        {
            CRUD.SaveAll(listObj);
        }

        public void Update(string ma, LoaiSanPham newInfo)
        {
            CRUD.Update(ma, newInfo);
        }
    }
}
