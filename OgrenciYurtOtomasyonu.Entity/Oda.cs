using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.Entity
{
    public class Oda : IEntity
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int odano;

        public int ODANO
        {
            get { return odano; }
            set { odano = value; }
        }

        private int odakapasite;

        public int ODAKAPASITE
        {
            get { return odakapasite; }
            set { odakapasite = value; }
        }

        private int odaaktif;

        public int ODAAKTIF
        {
            get { return odaaktif; }
            set { odaaktif = value; }
        }

        private bool odadurum;

        public bool ODADURUM
        {
            get { return odadurum; }
            set { odadurum = value; }
        }

    }
}
