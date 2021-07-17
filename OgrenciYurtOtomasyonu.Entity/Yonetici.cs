using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.Entity
{
    public class Yonetici : IEntity
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

        private string sifre;

        public string SIFRE
        {
            get { return sifre; }
            set { sifre = value; }
        }
    }
}
