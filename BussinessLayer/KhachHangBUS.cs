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
    class KhachHangBUS: ICRUD<KhachHang>
    {
        public delegate bool Condition(KhachHang khachhang);
        DataAcessLayer.Interface.ICRUD<KhachHang> CRUD = new KhachHangDAL();

        public void Add(KhachHang obj)
        {
            CRUD.Add(obj);
        }

        public void Delete(string ma)
        {
            CRUD.Delete(ma);
        }
        public void Delete(Condition condition)
        {
            List<KhachHang> khhang = GetList();
            for (int i = 0; i < khhang.Count; i++)
            {
                if (condition(khhang[i]))
                    khhang.RemoveAt(i);
            }
            SaveAll(khhang);
        }
        public int GetIndex(string ma)
        {
            return CRUD.GetIndex(ma);
        }

        public List<KhachHang> GetList()
        {
            return CRUD.GetList();
        }

        public void SaveAll(List<KhachHang> listObj)
        {
            CRUD.SaveAll(listObj);
        }

        public void Update(string ma, KhachHang newInfo)
        {
            CRUD.Update(ma, newInfo);
        }
    }
}
