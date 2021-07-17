using OgrenciYurtOtomasyonu.DAL;
using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.BLL
{
    public static class BolumBLL
    {
        static BolumDAL bolumDAL = new BolumDAL();
        public static List<Bolum> SelectAll()
        {
            return bolumDAL.SelectAll();
        }
        public static int Control(string ad)
        {
            int durum = 0;
            List<Bolum> bolums = SelectAll();
            List<Bolum> bolumler = bolums.Where(I => I.AD == ad).ToList();

            if (ad != null || ad != "")
            {
                if (bolumler.Count > 0)
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
        public static int Insert(Bolum Entity)
        {
            int eklenen = 0;
            if (Entity.AD != "")
            {
                eklenen = bolumDAL.Insert(Entity);
            }
            return eklenen;
        }
        public static int Delete(int ID)
        {
            int etkilenen = 0;
            if (ID > 0)
            {
                etkilenen = bolumDAL.Delete(ID);
            }
            else
            {
                etkilenen = 0;
            }
            return etkilenen;
        }
        public static int Update(Bolum Entity)
        {
            int durum = -1;
            if (Entity.AD != "")
            {
                durum = Helper.CommandExecuteNonQuery("BOLUM_Update", Entity, false);
                Helper.ConnectionOpenAndClose();
            }
            else
            {
                durum = -1;
            }
            return durum;
        }
    }

}
