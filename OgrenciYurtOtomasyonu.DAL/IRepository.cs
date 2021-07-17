using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYurtOtomasyonu.DAL
{
    public interface IRepository<T> where T : class , IEntity , new() 
    {
        List<T> SelectAll();
        T Select(int ID);
        int Insert(T Entity);
        int Update(T Entity);
        int Delete(int ID);
    }
}
