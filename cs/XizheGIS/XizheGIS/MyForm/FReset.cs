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
    public partial class FReset : Form
    {
        public FReset()
        {
            InitializeComponent();
        }
        public FReset(string username)
        {
            InitializeComponent();
            tbx_Username.Text = username;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string str_Username = tbx_Username.Text,
                   str_oldPassword = tbx_OldPassword.Text,
                   str_Password = tbx_NewPassword.Text,
                   str_rePassword = tbx_ReNewPassword.Text;
            // 判断用户名是否存在
            using (DataTable dt = MyUtils.SQL.GetDataTable(
                String.Format("SELECT COUNT(UserName) FROM TBUser WHERE UserName = '{0}'", str_Username)    
            )) {
                if (dt.Rows.Count == 0)
                { MessageBox.Show(String.Format("数据库中不存在【{0}】用户名", str_Username)); return; }
            }
            // 判断旧密码是否正确
            using (DataTable dt = MyUtils.SQL.GetDataTable(
                String.Format("SELECT UserPassword FROM TBUser WHERE UserName = '{0}'", str_Username)
            ))
            {
                if (!dt.Rows[0][0].ToString().Equals(str_oldPassword))
                { MessageBox.Show("输入旧密码错误"); return; }
            }
            // 判断两次密码是否一致
            if (str_Password != str_rePassword)
            { MessageBox.Show("两次输入的密码不一致"); return; }

            if (MyUtils.SQL.CommandSQL(
                String.Format("UPDATE TBUser SET UserPassword='{0}' WHERE UserName='{1}'", str_Password, str_Username)
            ) == 1)
            {
                MessageBox.Show("密码修改成功");
            }
            else 
                MessageBox.Show("密码修改失败");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
