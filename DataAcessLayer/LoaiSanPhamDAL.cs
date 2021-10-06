using CTBHChoShopMyPham.DataAcessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTBHChoShopMyPham.DataAcessLayer.DataTransferObjects;
using CTBHChoShopMyPham.DataAcessLayer.Interface;
using System.IO;

namespace CTBHChoShopMyPham.DataAcessLayer
{
    class LoaiSanPhamDAL:ICRUD<LoaiSanPham>
    {
        private string fileName = "loaisanpham.txt";

        public void Add(LoaiSanPham obj)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(obj);
            writer.Close();
        }

        public void Delete(string ma)
        {
            List<LoaiSanPham> loaisp = GetList();
            loaisp.RemoveAt(GetIndex(ma));
            SaveAll(loaisp);
        }

        public int GetIndex(string ma)
        {
            List<LoaiSanPham> loaisp = GetList();
            for (int i = 0; i < loaisp.Count; i++)
            {
                if (loaisp[i].MaLoai == ma || loaisp[i].TenLoai==ma || loaisp[i].TenTH==ma)
                    return i;
            }
            return -1;
        }

        public List<LoaiSanPham> GetList()
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Close();
            List<LoaiSanPham> loaisp = new List<LoaiSanPham>();
            StreamReader sr = new StreamReader(fileName);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] ttin = s.Split('#');
                loaisp.Add(new LoaiSanPham(ttin[0], ttin[1], ttin[2]));
            }
            sr.Close();
            return loaisp;
        }

        public void SaveAll(List<LoaiSanPham> listObj)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var loaisp in listObj)
            {
                sw.WriteLine(loaisp);
            }
            sw.Close();
        }

        public void Update(string ma, LoaiSanPham newInfo)
        {
            List<LoaiSanPham> loaisp = GetList();
            loaisp[GetIndex(ma)] = newInfo;
            SaveAll(loaisp);
        }
    }
}
