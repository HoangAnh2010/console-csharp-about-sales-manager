
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTBHChoShopMyPham.DataAcessLayer.Interface;

namespace CTBHChoShopMyPham.DataAcessLayer
{
    class HoaDonDAL : ICRUD<HoaDon>
    {
        private string fileName = "tonghoadon.txt";
        public void Add(HoaDon obj)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(obj);
            writer.Close();
        }

        public void Delete(string ma)
        {
            List<HoaDon> hdon = GetList();
            hdon.RemoveAt(GetIndex(ma));
            SaveAll(hdon);
        }
        public int GetIndex(string ma)
        {
            List<HoaDon> hdon = GetList();
            for (int i = 0; i < hdon.Count; i++)
            {
                if (hdon[i].MaHoaDon == ma)
                    return i;
            }
            return -1;
        }

        public List<HoaDon> GetList()
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Close();
            List<HoaDon> hdon = new List<HoaDon>();
            StreamReader sr = new StreamReader(fileName);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] ttin = s.Split('#');
                hdon.Add(new HoaDon(ttin[0],ttin[1],double.Parse(ttin[2]), DateTime.Parse(ttin[3]), ttin[4]));
            }
            sr.Close();
            return hdon;
        }

        public void SaveAll(List<HoaDon> listObj)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var hdon in listObj)
            {
                sw.WriteLine(hdon);
            }
            sw.Close();
        }

        public void Update(string ma, HoaDon newInfo)
        {
            List<HoaDon> hdon = GetList();
            hdon[GetIndex(ma)] = newInfo;
            SaveAll(hdon);
        }
    }
}

