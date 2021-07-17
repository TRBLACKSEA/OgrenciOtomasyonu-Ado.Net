using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.Entity
{
    public class Ogrenci : IEntity
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private string ad;

        public string AD
        {
            get { return ad; }
            set { ad = value; }
        }

        private string soyad;

        public string SOYAD
        {
            get { return soyad; }
            set { soyad = value; }
        }

        private string tc;

        public string TC
        {
            get { return tc; }
            set { tc = value; }
        }

        private string telefon;

        public string TELEFON
        {
            get { return telefon; }
            set { telefon = value; }
        }

        private DateTime dogumTarihi;

        public DateTime DOGUMTARIHI
        {
            get { return dogumTarihi; }
            set { dogumTarihi = value; }
        }

        private string mail;

        public string MAIL
        {
            get { return mail; }
            set { mail = value; }
        }

        private string veliAdSoyad;

        public string VELIADSOYAD
        {
            get { return veliAdSoyad; }
            set { veliAdSoyad = value; }
        }

        private string veliTelefon;

        public string VELITELEFON
        {
            get { return veliTelefon; }
            set { veliTelefon = value; }
        }

        private string veliAdres;

        public string VELIADRES
        {
            get { return veliAdres; }
            set { veliAdres = value; }
        }


        private string bolum;

        public string BOLUM
        {
            get { return bolum; }
            set { bolum = value; }
        }

    }
}
