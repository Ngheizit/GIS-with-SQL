using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XizheGIS.MyUtils
{
    class SQL
    {
        //获取配置文件的内容，AppConfig中的内容
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["SQLConnString"];

        /// <summary>
        /// 通过SQL语言返回查询出的DataTable内容
        /// </summary>
        /// <param name="SQL">查询语句</param>
        /// <returns>查询结果</returns>
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

        /// <summary>
        /// 通过执行SQL语句返回影响行数
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns></returns>
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
