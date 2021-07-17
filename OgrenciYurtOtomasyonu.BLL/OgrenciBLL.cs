using OgrenciYurtOtomasyonu.DAL;
using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.BLL
{
    public class OgrenciBLL
    {
        static OgrenciDAL ogrenciDAL = new OgrenciDAL();
        public static int Control(string tc)
        {
            int durum = 0;
            List<Ogrenci> ogrencis = SelectAll();
            List<Ogrenci> ogrenciler = ogrencis.Where(I => I.TC==tc).ToList();

            if (tc != null || tc != "")
            {
                if (ogrenciler.Count > 0)
                {
                    durum = 1;
                }
                else
                {
                    durum = 0;
                }
            }
            return durum;
        }

        public static List<Ogrenci> SelectAll()
        {
            return ogrenciDAL.SelectAll();
        }

        public static int Insert(Ogrenci Entity)
        {
            int eklenen = 0;
            if (Entity.AD != "" && Entity.SOYAD != "" && Entity.TC != "" && Entity.TELEFON != "" && Entity.DOGUMTARIHI !=null && Entity.MAIL != "" && Entity.VELIADSOYAD != "" && Entity.VELITELEFON != "" && Entity.VELIADRES != "" && Entity.BOLUM != "")
            {
                eklenen =  ogrenciDAL.Insert(Entity);
            }
            else
            {
                eklenen = 0;
            }
            return eklenen;
        }

        public static int Update(Ogrenci Entity)
        {
            int durum = 0;
            if(Entity.AD != "" && Entity.SOYAD != "" && Entity.TC != "" && Entity.TELEFON != "" && Entity.DOGUMTARIHI != null && Entity.MAIL != "" && Entity.VELIADSOYAD != "" && Entity.VELITELEFON != "" && Entity.VELIADRES != "" && Entity.BOLUM != "")
            {
                durum = ogrenciDAL.Update(Entity);
            }
            else
            {
                durum = 0;
            }
            return durum;
        }

        public static int Delete(int ID)
        {
            int etkilenen = ogrenciDAL.Delete(ID);
            return etkilenen;
        }
    }
}
