using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using CTBHChoShopMyPham.DataAcessLayer.Interface;
using System.Collections.Generic;
using System.IO;
namespace CTBHChoShopMyPham.DataAcessLayer
{
    class KhachHangDAL : ICRUD<KhachHang>
    {
        private string fileName = "khachhang.txt";

        public void Add(KhachHang obj)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(obj);
            writer.Close();
        }

        public void Delete(string ma)
        {
            List<KhachHang> khachhang = GetList();
            khachhang.RemoveAt(GetIndex(ma));
            SaveAll(khachhang);
        }

        public int GetIndex(string ma)
        {
            List<KhachHang> khachHang = GetList();
            for (int i = 0; i < khachHang.Count; i++)
            {
                if (khachHang[i].MaKH == ma)
                    return i;
            }
            return -1;
        }

        public List<KhachHang> GetList()
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Close();
            List<KhachHang> khachhang = new List<KhachHang>();
            StreamReader sr = new StreamReader(fileName);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] ttin = s.Split('#');
                khachhang.Add(new KhachHang(ttin[0], ttin[1], ttin[2], ttin[3]));
            }
            sr.Close();
            return khachhang;
        }

        public void SaveAll(List<KhachHang> listObj)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var khachhang in listObj)
            {
                sw.WriteLine(khachhang);
            }
            sw.Close();
        }

        public void Update(string ma, KhachHang newInfo)
        {
            List<KhachHang> khachhang = GetList();
            khachhang[GetIndex(ma)] = newInfo;
            SaveAll(khachhang);
        }
    }
}
