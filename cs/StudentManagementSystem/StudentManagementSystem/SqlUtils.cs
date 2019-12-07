using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public delegate void UpdataDatabaseView();
    class SqlUtils
    {
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["SQLConnString"];
        private static DataTable GetDataTable(string SQL)
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
        private static int CommandSQL(string SQL)
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

        public static void UpdataDatabaseView(DataGridView dataGridView)
        {
            DataTable dt = GetDataTable("SELECT * FROM StudentInfo");
            dataGridView.DataSource = dt;
        }

        public static bool AddStudent(string sid, string sname, string ssex, string sbirth, string shome)
        {
            if (CommandSQL(
                String.Format("INSERT INTO  StudentInfo (SID,SName,SSex,SBirth,SHome) VALUES ('{0}','{1}','{2}','{3}','{4}')",
                                 sid, sname, ssex, sbirth, shome)) != 0)
            {
                return true;
            }
            else
                return false;
        }
        public static string GetIdFromSId(string sid)
        {
            DataTable dt = GetDataTable(String.Format("SELECT Id FROM StudentInfo WHERE SID = '{0}'", sid));
            return dt.Rows[0][0].ToString();
        }
        public static bool EditStudent(string id, string sid, string sname, string ssex, string sbirth, string shome)
        {
            if (CommandSQL(
                    String.Format("UPDATE StudentInfo SET SID = '{0}', SName = '{1}', SSex = '{2}', SBirth = '{3}', SHome = '{4}' WHERE  Id = '{5}'",
                                    sid, sname, ssex, sbirth, shome, id)) != 0)
            {
                return true;
            }
            else
                return false;
        }
        public static bool DeleteStudent(string id)
        {
            if (CommandSQL(String.Format("DELETE FROM StudentInfo WHERE Id= '{0}'", id)) != 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
