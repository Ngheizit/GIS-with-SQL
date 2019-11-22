using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeizitGIS
{
    public partial class FormReset : Form
    {
        public FormReset()
        {
            InitializeComponent();
        }
        public FormReset(string userName)
        {
            InitializeComponent();
            tbx_username.Text = userName;
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            if ((Button)sender == btn_reset)
            {
                string str_Username = tbx_username.Text,
                       str_oldPassword = tbx_oldPassword.Text,
                       str_Password = tbx_password.Text,
                       str_rePassword = tbx_rePassword.Text;
                // 判断用户名是否存在
                string sql_UserCount = String.Format("SELECT COUNT(UserName) FROM TBUser WHERE UserName = '{0}'", str_Username);
                DataTable dt_UserCount = SQLHelper.GetDataTable(sql_UserCount);
                if (!dt_UserCount.Rows[0][0].Equals(0))
                {
                    // 判断旧密码是否正确
                    string sql_Password = String.Format("SELECT UserPassword FROM TBUser WHERE UserName = '{0}'", str_Username);
                    DataTable dt_Password = SQLHelper.GetDataTable(sql_Password);
                    if (!dt_Password.Rows[0][0].ToString().Equals(str_oldPassword))
                    { 
                        MessageBox.Show("输入旧密码错误");
                        return;
                    }

                    // 判断两次密码是否一致
                    if (str_Password == str_rePassword)
                    {
                        string sql_PasswordUpdate = String.Format("UPDATE TBUser SET UserPassword='{0}' WHERE UserName='{1}'", str_Password, str_Username);
                        if (SQLHelper.CommandSQL(sql_PasswordUpdate) == 1)
                        { 
                            MessageBox.Show("密码修改成功");
                        } else { MessageBox.Show("密码修改失败"); }
                    } else { MessageBox.Show("两次输入的密码不一致"); }
                } else { MessageBox.Show(String.Format("数据库中不存在【{0}】用户名", str_Username)); }

                return;
            }

            if ((Button)sender == btn_cancel)
            {
                this.Close();
                return;
            }
        }
    }
}
