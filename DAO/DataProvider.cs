using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyQuanCafe.DAO
{
    public class DataProvider
    {
        //design partern Singleton
        private static DataProvider instanse;
        public static DataProvider Instance
        {
            get
            {
                if (instanse == null)
                {
                    instanse = new DataProvider();
                }
                return instanse;
            }
            private set => instanse = value;
        }
        private DataProvider()
        {
        }

        private readonly string connection = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            SqlConnection Conect = new SqlConnection(connection);
            DataTable Table = new DataTable();
            try
            {
                Conect.Open();
                SqlCommand Command = new SqlCommand(query, Conect);
                if (parameter != null)
                {
                    string[] ListItems = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListItems)
                    {
                        if (item.Contains('@'))
                        {
                            Command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                Adapter.Fill(Table);
                return Table;
            }
            catch (Exception)
            {
                return Table;
            }
            finally
            {
                Conect.Close();
            }
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            SqlConnection Conect = new SqlConnection(connection);
            int result = 0;
            try
            {
                Conect.Open();
                SqlCommand Command = new SqlCommand(query, Conect);
                if (parameter != null)
                {
                    string[] ListItems = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListItems)
                    {
                        if (item.Contains('@'))
                        {
                            Command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                result = Command.ExecuteNonQuery();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                Conect.Close();
            }
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            SqlConnection Conect = new SqlConnection(connection);
            object result = 0;
            try
            {
                Conect.Open();
                SqlCommand Command = new SqlCommand(query, Conect);
                if (parameter != null)
                {
                    string[] ListItems = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListItems)
                    {
                        if (item.Contains('@'))
                        {
                            Command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                result = Command.ExecuteScalar();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                Conect.Close();
            }
        }
    }
}
