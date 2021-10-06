using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using CTBHChoShopMyPham.DataAcessLayer.Interface;

namespace CTBHChoShopMyPham.DataAcessLayer
{
    class ChiTietHoaDonDAL:ICRUD<ChiTietHoaDon>
    {
        private string fileName = "chitiethoadon.txt";        
        public void Add(ChiTietHoaDon obj)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(obj);
            writer.Close();
        }

        public void Delete(string ma)
        {
            List<ChiTietHoaDon> hdon = GetList();
            hdon.RemoveAt(GetIndex(ma));
            SaveAll(hdon);
        }
        public int GetIndex(string ma)
        {
            List<ChiTietHoaDon> hdon = GetList();
            for (int i = 0; i < hdon.Count; i++)
            {
                if (hdon[i].MaHD+hdon[i].MaSP == ma )
                    return i;
            }
            return -1;
        }

        public List<ChiTietHoaDon> GetList()
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Close();
            List<ChiTietHoaDon> hdon = new List<ChiTietHoaDon>();
            StreamReader sr = new StreamReader(fileName);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] ttin = s.Split('#');
                hdon.Add(new ChiTietHoaDon(ttin[0], ttin[1], int.Parse(ttin[2]), double.Parse(ttin[3])));
            }
            sr.Close();
            return hdon;
        }       

        public void SaveAll(List<ChiTietHoaDon> listObj)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var hdon in listObj)
            {
                sw.WriteLine(hdon);
            }
            sw.Close();
        }

        public void Update(string ma, ChiTietHoaDon newInfo)
        {
            List<ChiTietHoaDon> hdon = GetList();
            hdon[GetIndex(ma)] = newInfo;
            SaveAll(hdon);
        }
    }
}
