using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTBHChoShopMyPham.DataAcessLayer.Interface;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using System.IO;

namespace CTBHChoShopMyPham.DataAcessLayer
{
    class NguoiBanHangDAL:ICRUD<NguoiBanHang>
    {
        private string fileName = "nguoibanhang.txt";

        public void Add(NguoiBanHang obj)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(obj);
            writer.Close();
        }

        public void Delete(string ma)
        {
            List<NguoiBanHang> nbh = GetList();
            nbh.RemoveAt(GetIndex(ma));
            SaveAll(nbh);
        }

        public int GetIndex(string ma)
        {
            List<NguoiBanHang> nbh = GetList();
            for (int i = 0; i < nbh.Count; i++)
            {
                if (nbh[i].MaNBH == ma || nbh[i].TenNBH==ma || nbh[i].Sdt == ma)
                    return i;
            }
            return -1;
        }

        public List<NguoiBanHang> GetList()
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Close();
            List<NguoiBanHang> nbh = new List<NguoiBanHang>();
            StreamReader sr = new StreamReader(fileName);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] ttin = s.Split('#');
                nbh.Add(new NguoiBanHang(ttin[0], ttin[1], ttin[2], ttin[3], ttin[4]));
            }
            sr.Close();
            return nbh;
        }

        public void SaveAll(List<NguoiBanHang> listObj)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var nbh in listObj)
            {
                sw.WriteLine(nbh);
            }
            sw.Close();
        }

        public void Update(string ma, NguoiBanHang newInfo)
        {
            List<NguoiBanHang> nbh = GetList();
            nbh[GetIndex(ma)] = newInfo;
            SaveAll(nbh);
        }
    }
}
