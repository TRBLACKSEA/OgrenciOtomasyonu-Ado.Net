using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciYurtOtomasyonu.DAL
{
    public static class Helper
    {
        public static SqlConnection connection = null;
        public static void ConnectionLoad()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["OgrenciYurtOtomasyonuVeriTabani"].ConnectionString;
        }
        public static void ConnectionOpenAndClose()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
            }
        }

        public static SqlDataReader CommandExecuteReader(string procedure) // Using at SelectAll
        {
            ConnectionLoad();
            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            if (command.Connection.State == ConnectionState.Closed)
            {
                ConnectionOpenAndClose();
            }
            return command.ExecuteReader();
        }
        public static SqlDataReader CommandExecuteReader(string procedure, SqlParameter parameter) // Using at Select
        {
            ConnectionLoad();
            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (command.Connection.State == ConnectionState.Closed)
            {
                ConnectionOpenAndClose();
            }
            command.Parameters.Add(parameter);
            return command.ExecuteReader();
        }
        public static int CommandExecuteNonQuery(string procedure, SqlParameter parameter) //Using at Delete
        {
            ConnectionLoad();
            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (command.Connection.State == ConnectionState.Closed)
            {
                ConnectionOpenAndClose();
            }
            command.Parameters.Add(parameter);
            return command.ExecuteNonQuery();
        }
        public static int CommandExecuteNonQuery<T>(string procedure, T Entity, bool InsertOrUpdate = false) where T : class, IEntity, new() //false mean is method work as update //USING AT INSERT AND UPDATE
        {
            ConnectionLoad();
            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (command.Connection.State == ConnectionState.Closed)
            {
                ConnectionOpenAndClose();
            }

            PropertyInfo[] ınfos = Entity.GetType().GetProperties();
            if (!InsertOrUpdate) //Update
            {
                for (int i = 0; i < ınfos.Length; i++)
                {
                    command.Parameters.AddWithValue(ınfos[i].Name, Entity.GetType().GetProperty(ınfos[i].Name).GetValue(Entity, null));
                }
            }
            else //Insert
            {
                for (int i = 1; i < ınfos.Length; i++)
                {
                    command.Parameters.AddWithValue(ınfos[i].Name, Entity.GetType().GetProperty(ınfos[i].Name).GetValue(Entity, null));
                }
            }
            return command.ExecuteNonQuery();
        }
    }
}
