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
    public class BolumDAL : IBolumDAL
    {
        public int Delete(int ID)
        {
            int etkilenen = 0;
            try
            {
                SqlParameter id = new SqlParameter("ID", SqlDbType.Int);
                id.Value = ID;
                etkilenen = Helper.CommandExecuteNonQuery("BOLUM_Delete", id);
            }
            catch (Exception)
            {
                etkilenen = 0;
            }
            return etkilenen;
        }

        public int Insert(Bolum Entity)
        {
            int eklenen = 0;
            try
            {
                eklenen = Helper.CommandExecuteNonQuery("BOLUM_Insert", Entity, true);
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                Helper.ConnectionOpenAndClose();
                MessageBox.Show(e.ToString());
                eklenen = 0;
            }
            return eklenen;
        }

        public Bolum Select(int ID)
        {

            try
            {

            }
            catch (Exception)
            {

                
            }
            return null;
        }

        public List<Bolum> SelectAll()
        {
            Bolum bolum = null;
            List<Bolum> bolumler = null;
            try
            {
                SqlDataReader reader = Helper.CommandExecuteReader("BOLUM_SelectAll");

                if(reader.HasRows)
                {
                    bolumler = new List<Bolum>();
                    while(reader.Read())
                    {
                        bolum = new Bolum()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            AD = reader["ad"].ToString()
                        };
                        bolumler.Add(bolum);
                    }
                }
                reader.Close();
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                bolumler = null;
            }
            return bolumler;
        }

        public int Update(Bolum Entity)
        {
            int durum = -1;
            try
            {
                durum = Helper.CommandExecuteNonQuery("BOLUM_Update", Entity, false);
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Helper.ConnectionOpenAndClose();
                durum = -1;
            }
            return durum;
        }
    }
}
