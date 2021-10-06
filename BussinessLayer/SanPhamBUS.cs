using CTBHChoShopMyPham.BussinessLayer.Interface;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTBHChoShopMyPham.DataAcessLayer;

namespace CTBHChoShopMyPham.BussinessLayer
{
    class SanPhamBUS : ICRUD<SanPham>
    {
        public delegate bool Condition(SanPham sanpham);
        DataAcessLayer.Interface.ICRUD<SanPham> CRUD = new SanPhamDAL(); 

        public void Add(SanPham obj)
        {
            CRUD.Add(obj);
        }

        public void Delete(string ma)
        {
            CRUD.Delete(ma);
        }
        public void Delete(Condition condition)
        {
            List<SanPham> sp = GetList();
            for(int i=0; i<sp.Count;i++)
            {
                if (condition(sp[i]))
                    sp.RemoveAt(i);
            }
            SaveAll(sp);
        }

        public int GetIndex(string ma)
        {
            return CRUD.GetIndex(ma);
        }

        public List<SanPham> GetList()
        {
            return CRUD.GetList();
        }

        public void SaveAll(List<SanPham> listObj)
        {
            CRUD.SaveAll(listObj);
        }

        public void Update(string ma, SanPham newInfo)
        {
            CRUD.Update(ma, newInfo);
        }

        public SanPham GetSanPham(Condition condition, List<SanPham> sanPhams)
        {
            foreach(var sp in sanPhams)
            {
                if (condition(sp))
                    return sp;
            }
            return null;
        }

        public int GetIndex(Condition condition, List<SanPham> sanPhams)
        {
            for(int i = 0; i< sanPhams.Count; i++)
            {
                if (condition(sanPhams[i]))
                    return i;
            }
            return -1;
        }
    }

}
