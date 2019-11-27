using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XizheGIS.MyForm
{
    public partial class FSignIn : Form
    {
        private string id;
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        private string username;
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public FSignIn()
        {
            InitializeComponent();
        }

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            string strUsername = tbx_Username.Text,
                   strPassword = tbx_Password.Text;

            using (DataTable dt = MyUtils.SQL.GetDataTable(
                String.Format("SELECT * FROM TBUser WHERE UserName = '{0}'", strUsername)
            )){
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(String.Format("数据库中不存在【{0}】用户名", strUsername));
                    return;
                }
                else
                {
                    this.id = dt.Rows[0][0].ToString();
                    this.username = dt.Rows[0][1].ToString();
                }
            }
            using (DataTable dt_Password = MyUtils.SQL.GetDataTable(
                String.Format("SELECT UserPassword FROM TBUser WHERE UserName = '{0}'", strUsername)   
             )) {
                 if (dt_Password.Rows[0][0].ToString() != strPassword)
                 {
                     MessageBox.Show("密码不正确");
                     return;
                 }
                 else
                     this.DialogResult = DialogResult.OK;
            }
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            new MyForm.FSignUp().Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ResetPassword_Click(object sender, EventArgs e)
        {
            new MyForm.FReset().Show();
        }
    }
}
