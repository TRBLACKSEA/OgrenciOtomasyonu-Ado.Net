using OgrenciYurtOtomasyonu.DAL;
using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.BLL
{
    public static class OdaBLL
    {
        public static List<Oda> SelectAll()
        {
            OdaDAL odaDAL = new OdaDAL();
            return odaDAL.SelectAll();
        }
    }
}
