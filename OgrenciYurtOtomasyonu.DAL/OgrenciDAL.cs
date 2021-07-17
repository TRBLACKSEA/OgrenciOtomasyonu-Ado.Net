using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciYurtOtomasyonu.Entity;

namespace OgrenciYurtOtomasyonu.DAL
{
    public class OgrenciDAL : IOgrenciDAL
    {
        public int Delete(int ID)
        {
            int etkilenen = 0;
            try
            {
                SqlParameter id = new SqlParameter("ID", SqlDbType.Int);
                id.Value = ID;
                etkilenen = Helper.CommandExecuteNonQuery("OGRENCI_Delete", id);
            }
            catch (Exception)
            {
                Helper.ConnectionOpenAndClose();
                etkilenen = -1;
            }
            return etkilenen;
        }

        public int Insert(Ogrenci Entity)
        {
            int eklenen = 0;
            try
            {
                eklenen = Helper.CommandExecuteNonQuery("OGRENCI_Insert", Entity, true);
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                eklenen = 0;
            }
            return eklenen;
            
        }

        public Ogrenci Select(int ID)
        {
            return null;
        }

        public List<Ogrenci> SelectAll()
        {
            Ogrenci ogrenci = null;
            List<Ogrenci> ogrenciler = null;
            try
            {
                SqlDataReader reader = Helper.CommandExecuteReader("OGRENCI_SelectAll");
                if (reader.HasRows)
                {
                    ogrenciler = new List<Ogrenci>();
                    while (reader.Read())
                    {
                        ogrenci = new Ogrenci()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            AD = reader["ad"].ToString(),
                            SOYAD = reader["soyad"].ToString(),
                            TC = reader["tc"].ToString(),
                            TELEFON = reader["telefon"].ToString(),
                            DOGUMTARIHI = Convert.ToDateTime(reader["dogumtarihi"]),
                            MAIL = reader["mail"].ToString(),
                            VELIADSOYAD = reader["veliAdSoyad"].ToString(),
                            VELITELEFON = reader["veliTelefon"].ToString(),
                            VELIADRES = reader["veliAdres"].ToString(),
                            BOLUM = reader["bolum"].ToString()
                        };
                        ogrenciler.Add(ogrenci);
                    }
                }
                reader.Close();
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

                ogrenciler = null;
            }

            return ogrenciler;

        }

        public int Update(Ogrenci Entity)
        {
            int durum = 0;
            try
            {
                durum = Helper.CommandExecuteNonQuery("OGRENCI_Update", Entity, false);
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception)
            {
                durum = 0;
                Helper.ConnectionOpenAndClose();
            }
            return durum;
        }
    }
}
