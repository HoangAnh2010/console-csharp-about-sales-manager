using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBHChoShopMyPham.DataAcessLayer.Interface
{
    interface ICRUD<T>
    {
        List<T> GetList();
        void Add(T obj);
        void Delete(string ma);
        void Update(string ma, T newInfo);
        void SaveAll(List<T> listObj);
        int GetIndex(string ma);
    }
}
