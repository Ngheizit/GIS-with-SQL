using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;


namespace GDBdebug
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 数据库连接
            string strCon = "Data Source=.;Initial Catalog=NhztGDB;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            //MessageBox.Show(sqlCon.State.ToString());

            //// 使用Command对象通过SQL命令操作数据库
            //SqlCommand sqlCom = new SqlCommand();
            //sqlCom.Connection = sqlCon;
            //sqlCom.CommandText = "UPDATE Student SET Sage = Sage+1"; // SQL语句：所有学生年龄+1
            //int i = sqlCom.ExecuteNonQuery(); // 返回执行SQL操作所影响的行数
            //MessageBox.Show(i.ToString());


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            //sqlCom.CommandText = "select * from Student";
            ////SqlDataReader sqlReader = sqlCom.ExecuteReader();
            ////for (int i = 0; i < sqlReader.FieldCount; i++)
            ////{
            ////    dataGridView1.Columns.Add(sqlReader.GetName(i), sqlReader.GetName(i));
            ////}
            ////while (sqlReader.Read())
            ////{
            ////    int count = sqlReader.FieldCount;
            ////    object[] objs = new object[count];
            ////    for (int j = 0; j < count; j++)
            ////    {
            ////        objs[j] = sqlReader.GetValue(j);
            ////    }
            ////    dataGridView1.Rows.Add(objs);
            ////}
            //SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            //sqlAdapter.SelectCommand = sqlCom;
            //DataSet ds = new DataSet();
            //sqlAdapter.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            sqlCom.CommandText = "select * from Student where Sno = @id";
            SqlParameter param = new SqlParameter("id", SqlDbType.NVarChar);
            param.Value = "201215121";
            sqlCom.Parameters.Add(param);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            sqlAdapter.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            sqlCon.Close();


        }
    }
}
