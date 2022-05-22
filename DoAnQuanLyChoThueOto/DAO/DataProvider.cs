using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        private string connectionSTR = @"Data Source=LAPTOP-4FQ2SPD6;Initial Catalog=QuanLyThueXeOtoDoAnLamLai;Integrated Security=True";

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    DataProvider.instance = new DataProvider();
                };
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conection = new SqlConnection(connectionSTR))
            {
                conection.Open();
                SqlCommand command = new SqlCommand(query, conection);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                conection.Close();
            }

            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection conection = new SqlConnection(connectionSTR))
            {
                conection.Open();
                SqlCommand command = new SqlCommand(query, conection);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                conection.Close();
            }

            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection conection = new SqlConnection(connectionSTR))
            {
                conection.Open();
                SqlCommand command = new SqlCommand(query, conection);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                conection.Close();
            }

            return data;
        }
    }
}
