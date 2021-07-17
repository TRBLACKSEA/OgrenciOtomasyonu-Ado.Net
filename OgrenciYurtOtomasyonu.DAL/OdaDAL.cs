using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciYurtOtomasyonu.Entity;

namespace OgrenciYurtOtomasyonu.DAL
{
    public class OdaDAL : IOdaDAL
    {
        public int Delete(int ID)
        {
            return 0;
        }

        public int Insert(Oda Entity)
        {
            return 0;
        }

        public Oda Select(int ID)
        {
            return null;
        }

        public List<Oda> SelectAll()
        {
            Oda oda = null;
            List<Oda> odalar = null;
            try
            {
                SqlDataReader reader = Helper.CommandExecuteReader("ODA_SelectAll");
                if (reader.HasRows)
                {
                    odalar = new List<Oda>();
                    while (reader.Read())
                    {
                        oda = new Oda()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            ODANO = Convert.ToInt32(reader["OdaNo"]),
                            ODAKAPASITE = Convert.ToInt32(reader["OdaKapasite"]),
                            ODAAKTIF = Convert.ToInt32(reader["OdaAktif"]),
                            ODADURUM = Convert.ToBoolean(reader["OdaDurum"])
                        };
                        odalar.Add(oda);
                    }
                }
                reader.Close();
                Helper.ConnectionOpenAndClose();
            }
            catch (Exception e)
            {
                odalar = null;
                MessageBox.Show(e.ToString());
            }
            return odalar;
        }

        public int Update(Oda Entity)
        {
            return 0;
        }
    }
}
