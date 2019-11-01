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
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            if ((Button)sender == btn_ok)
            {
                string str_Username = tbx_username.Text,
                       str_Password = tbx_password.Text,
                       str_Repassword = tbx_rePassword.Text;
                // 判断两次密码是否一致
                if (str_Password == str_Repassword)
                {
                    // 判断用户名是否存在
                    string sql_UserCount = String.Format("SELECT COUNT(Username) FROM Users WHERE Username = '{0}'", str_Username);
                    DataTable dt_UserCount = SQLHelper.GetDataTable(sql_UserCount);
                    if (dt_UserCount.Rows[0][0].Equals(0))
                    {
                        // 插入用户名和密码
                        string sql_NewUser = String.Format("INSERT INTO Users (Username, Password) VALUES ('{0}', '{1}')", str_Username, str_Password);
                        if (SQLHelper.CommandSQL(sql_NewUser) == 1)
                        {
                            MessageBox.Show("用户注册成功");
                        } else { MessageBox.Show("用户注册失败"); }
                    } else { MessageBox.Show(String.Format("数据库中已存在【{0}】用户名", str_Username)); }
                } else { MessageBox.Show("两次输入的密码不一致");}

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
