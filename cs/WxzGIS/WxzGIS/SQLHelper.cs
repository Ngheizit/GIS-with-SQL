using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxzGIS
{
    class SQLHelper
    {
        //获取配置文件的内容，AppConfig中的内容
        public static readonly string ConnectionString = "Data Source=.;Initial Catalog=HeizitGIS;Integrated Security=True";

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

        /// <summary>
        /// SQL语句：查询完整表 （单表查询）
        /// </summary>
        /// <param name="FROM">需要查询的表</param>
        /// <returns>返回查询某个完整表的SQL语句 字符串类型</returns>
        public static string SQL_SelectAll(string FROM)
        {
            return String.Format("SELECT * FROM {0}", FROM);
        }

        /// <summary>
        /// SQL语句：查询指定表中指定的元组（单表查询）
        /// </summary>
        /// <param name="FROM">需要查询的表</param>
        /// <param name="WHERE_field">规则字段</param>
        /// <param name="WHERE_value">规则值</param>
        /// <returns></returns>
        public static string SQL_SelectAll(string FROM, string WHERE_field, string WHERE_value)
        {
            return String.Format("SELECT * FROM {0} WHERE {1} = '{2}'", FROM, WHERE_field, WHERE_value);
        }

        /// <summary>
        /// SQL语句：查询指定表中的指定列 （单表查询）
        /// </summary>
        /// <param name="FROM">需要查询的表</param>
        /// <param name="fields">需要查询的列集合</param>
        /// <returns>返回查询某表的执行列的SQL语句 字符串类型</returns>
        public static string SQL_SelectCols(string FROM, params string[] fields)
        {
            string str_fields = "";
            for (int i = 0; i < fields.Length; i++)
            {
                if (i == 0)
                    str_fields += fields[0];
                else
                    str_fields += "," + fields[i];
            }
            return String.Format("SELECT {0} FROM {1}", str_fields, FROM);
        }

        /// <summary>
        /// SQL语句：在指定表中插入一个元组
        /// </summary>
        /// <param name="FROM">需要插入的表</param>
        /// <param name="fields">元组字段</param>
        /// <param name="values">元组字段值</param>
        /// <returns></returns>
        public static string SQL_Insert(string FROM, string fields, string values)
        {
            return String.Format("INSERT INTO {0} ({1}) VALUES ({2})", FROM, fields, values);
        }
    }
}
