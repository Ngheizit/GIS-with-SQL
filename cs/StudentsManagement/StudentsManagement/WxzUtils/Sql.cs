using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StudentsManagement.WxzUtils
{
    class Sql
    {
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["SQLConnString"];

        public static DataTable GetDataTable(string SQL)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCom = new SqlCommand())
                {
                    sqlCom.Connection = connection;
                    sqlCom.CommandText = SQL;
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlAdapter.SelectCommand = sqlCom;
                    DataTable dt = new DataTable();
                    sqlAdapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int CommandSQL(string SQL)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCom = new SqlCommand())
                {
                    sqlCom.Connection = connection;
                    sqlCom.CommandText = SQL;
                    int count = sqlCom.ExecuteNonQuery();
                    return count;
                }
            }
        }
    }
}
