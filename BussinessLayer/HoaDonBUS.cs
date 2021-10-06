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
    class HoaDonBUS : ICRUD<HoaDon>
    {
        DataAcessLayer.Interface.ICRUD<HoaDon> cRUD = new HoaDonDAL();
        public void Add(HoaDon obj)
        {
            cRUD.Add(obj);
        }

        public void Delete(string ma)
        {
            cRUD.Delete(ma);
        }

        public int GetIndex(string ma)
        {
            return cRUD.GetIndex(ma);
        }

        public List<HoaDon> GetList()
        {
            return cRUD.GetList();
        }

        public void SaveAll(List<HoaDon> listObj)
        {
            cRUD.SaveAll(listObj);
        }

        public void Update(string ma, HoaDon newInfo)
        {
            cRUD.Update(ma, newInfo);
        }
    }
}
