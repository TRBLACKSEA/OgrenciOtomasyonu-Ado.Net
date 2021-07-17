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
    public class YoneticiDAL : IYoneticiDAL
    {
        public int Delete(int ID)
        {
            int etkilenen = 0;
            try
            {
                SqlParameter id = new SqlParameter("ID", SqlDbType.Int);
                id.Value = ID;
                etkilenen = Helper.CommandExecuteNonQuery("YONETICI_Delete", id);
            }
            catch (Exception)
            {
                Helper.ConnectionOpenAndClose();
                etkilenen = -1;
            }
            return etkilenen;
        }

        public int Insert(Yonetici Entity)
        {
            int eklenen = 0;
            try
            {
                eklenen = Helper.CommandExecuteNonQuery("YONETICI_Insert", Entity,true);
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                Helper.ConnectionOpenAndClose();
                eklenen = 0;
                MessageBox.Show(e.ToString());
            }
            return eklenen;
        }

        public int Update(Yonetici Entity)
        {
            int durum = -1;
            try
            {
                durum = Helper.CommandExecuteNonQuery("YONETICI_Update", Entity, false);
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                Helper.ConnectionOpenAndClose();
                durum = -1;
                MessageBox.Show(e.ToString());
            }
            return durum;
        }

        public Yonetici Select(int ID)
        {
            Yonetici item = null;
            try
            {

                SqlParameter id = new SqlParameter("ID", SqlDbType.Int);
                id.Value = ID;
                SqlDataReader reader = Helper.CommandExecuteReader("YONETICI_Select", id);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = new Yonetici()
                        {
                            ID = Convert.ToInt32("id"),
                            AD = reader["ad"].ToString(),
                            SIFRE = reader["sifre"].ToString()
                        };
                    }
                }

                reader.Close();
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception)
            {
                Helper.ConnectionOpenAndClose();
                item = null;
            }
            return item;
        }

        public List<Yonetici> SelectAll()
        {
            Yonetici yonetici = null;
            List<Yonetici> yoneticiler = new List<Yonetici>();
            try
            {
                SqlDataReader reader = Helper.CommandExecuteReader("YONETICI_SelectAll");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yonetici = new Yonetici()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            AD = reader["ad"].ToString(),
                            SIFRE = reader["sifre"].ToString()
                        };
                        yoneticiler.Add(yonetici);
                    }
                }
                reader.Close();
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception)
            {
                Helper.ConnectionOpenAndClose();
                yoneticiler = null;
            }
            return yoneticiler;
        }

        public int YoneticileriEkle(List<Yonetici> yoneticiler)
        {
            int eklenen = 0;
            SqlCommand command;
            List<Yonetici> yeniYoneticiler = new List<Yonetici>();
            try
            {
                Helper.ConnectionLoad();
                command = new SqlCommand("insert into Yoneticiler (ad,sifre) values(@AD,@SIFRE)", Helper.connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    Helper.ConnectionOpenAndClose();
                }

                foreach (Yonetici item in yoneticiler)
                {
                    command = new SqlCommand("insert into Yoneticiler (ad,sifre) values(@AD,@SIFRE)", Helper.connection);
                    command.Parameters.AddWithValue("@AD", item.AD);
                    command.Parameters.AddWithValue("@SIFRE", item.SIFRE);
                    eklenen += command.ExecuteNonQuery();
                }
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception)
            {
                Helper.ConnectionOpenAndClose();
                eklenen = 0;
            }
            return eklenen;
        }

        public int YoneticiLogin(string kullaniciAdi, string sifre)
        {
            Yonetici yonetici = null;
            List<Yonetici> yoneticiler = new List<Yonetici>();
            int durum = -1;
            try
            {
                Helper.ConnectionLoad();
                SqlCommand command = new SqlCommand("YONETICI_login", Helper.connection);
                command.CommandType = CommandType.StoredProcedure;

                if (command.Connection.State == ConnectionState.Closed)
                {
                    Helper.ConnectionOpenAndClose();
                }

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yonetici = new Yonetici()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            AD = reader["ad"].ToString(),
                            SIFRE = reader["sifre"].ToString()
                        };
                        yoneticiler.Add(yonetici);
                    }
                }

                reader.Close();
                Helper.ConnectionOpenAndClose();

                var Yoneticiler = yoneticiler.Where(I => I.AD == kullaniciAdi && I.SIFRE == sifre).ToList();

                if (Yoneticiler.Count > 0)
                {
                    durum = 1;
                }
                else
                {
                    durum = -1;
                }
            }
            catch (Exception e)
            {
                Helper.ConnectionOpenAndClose();
                MessageBox.Show(e.ToString());
            }
            return durum;
        }

    }
}
