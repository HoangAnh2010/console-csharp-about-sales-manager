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
    class NguoiBanHangBUS : ICRUD<NguoiBanHang>
    {
        DataAcessLayer.Interface.ICRUD<NguoiBanHang> CRUD = new NguoiBanHangDAL();

        public void Add(NguoiBanHang obj)
        {
            CRUD.Add(obj);
        }

        public void Delete(string ma)
        {
            CRUD.Delete(ma);
        }

        public int GetIndex(string ma)
        {
            return CRUD.GetIndex(ma);
        }

        public List<NguoiBanHang> GetList()
        {
            return CRUD.GetList();
        }

        public void SaveAll(List<NguoiBanHang> listObj)
        {
            CRUD.SaveAll(listObj);
        }

        public void Update(string ma, NguoiBanHang newInfo)
        {
            CRUD.Update(ma, newInfo);
        }
    }
}
