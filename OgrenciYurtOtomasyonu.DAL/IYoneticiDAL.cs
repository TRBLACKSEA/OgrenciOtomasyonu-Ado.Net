using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.DAL
{
    public interface IYoneticiDAL : IRepository<Yonetici>
    {
        int YoneticiLogin(string kullaniciAdi,string sifre);
        int YoneticileriEkle(List<Yonetici> yoneticiler);
    }
}
