using CTBHChoShopMyPham.DataAcessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System.IO;

namespace CTBHChoShopMyPham.DataAcessLayer
{
    class SanPhamDAL : ICRUD<SanPham>
    {
        private string fileName = "sanpham.txt";

        public void Add(SanPham obj)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(obj);
            writer.Close();
        }

        public void Delete(string ma)
        {
            List<SanPham> sp = GetList();
            sp.RemoveAt(GetIndex(ma));
            SaveAll(sp);
        }

        public int GetIndex(string ma)
        {
            List<SanPham> sp = GetList();
            for(int i=0; i<sp.Count;i++)
            {
                if (sp[i].MaSP == ma || sp[i].TenSP == ma || sp[i].MaLoai == ma)
                    return i;
            }
            return -1;
        }

        public List<SanPham> GetList()
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Close();
            List<SanPham> sp = new List<SanPham>();
            StreamReader sr = new StreamReader(fileName);
            string s = "";
            while((s = sr.ReadLine())!= null)
            {
                string[] ttin = s.Split('#');
                sp.Add(new SanPham(ttin[0], ttin[1], ttin[2], int.Parse(ttin[3]), DateTime.Parse(ttin[4]), DateTime.Parse(ttin[5]), int.Parse(ttin[6])));
            }
            sr.Close();
            return sp;
        }

        public void SaveAll(List<SanPham> listObj)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach(var sp in listObj)
            {
                sw.WriteLine(sp);
            }
            sw.Close();
        }

        public void Update(string ma, SanPham newInfo)
        {
            List<SanPham> sp = GetList();
            sp[GetIndex(ma)] = newInfo;
            SaveAll(sp);
        }
        
    }
}
