using OgrenciYurtOtomasyonu.DAL;
using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.BLL
{
    public static class YoneticiBLL
    {
        public static int Delete(int ID)
        {
            YoneticiDAL yoneticiDAL = new YoneticiDAL();
            return yoneticiDAL.Delete(ID);
        }
        public static int Update(Yonetici Entity)
        {
            int durum = -1;
            if ((Entity.AD != null || Entity.AD != "") && (Entity.SIFRE != null || Entity.SIFRE != ""))
            {
                YoneticiDAL yoneticiDAL = new YoneticiDAL();
                durum = yoneticiDAL.Update(Entity);
            }
            return durum;
        }
        public static int YoneticiLogin(string kullaniciAdi, string sifre)
        {
            int durum;
            if (kullaniciAdi != "" && sifre != "")
            {
                YoneticiDAL yoneticiDAL = new YoneticiDAL();
                durum = yoneticiDAL.YoneticiLogin(kullaniciAdi, sifre);
            }
            else
            {
                durum = -1;
            }
            return durum;
        }

        public static int Insert(Yonetici Entity)
        {
            int eklenen = 0;
            if (Entity.SIFRE != null && Entity.AD != null)
            {
                YoneticiDAL yoneticiDAL = new YoneticiDAL();
                eklenen = yoneticiDAL.Insert(Entity);
            }
            return eklenen;
        }
        public static Yonetici Select(int ID)
        {
            YoneticiDAL yoneticiDAL = new YoneticiDAL();
            Yonetici yonetici = new Yonetici()
            {
                ID = ID,
                AD = yoneticiDAL.Select(ID).AD,
                SIFRE = yoneticiDAL.Select(ID).SIFRE
            };
            return yonetici;
        }
        public static List<Yonetici> SelectAll()
        {
            YoneticiDAL yoneticiDAL = new YoneticiDAL();
            return yoneticiDAL.SelectAll();
        }

        public static int YoneticileriEkle(List<Yonetici> yoneticiler)
        {
            YoneticiDAL yoneticiDAL = new YoneticiDAL();
            return yoneticiDAL.YoneticileriEkle(yoneticiler);
        }
    }
}
