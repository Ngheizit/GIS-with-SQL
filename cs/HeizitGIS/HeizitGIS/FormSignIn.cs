using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;

namespace HeizitGIS
{
    public partial class FormSignIn : Form
    {
        public FormSignIn()
        {
            InitializeComponent();
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            
            // 登录事件
            if ((Button)sender == btn_signIn)
            {
                string str_Username = tbx_username.Text,
                       str_Password = tbx_password.Text;
                // 判断用户名是否存在
                string sql_UserCount = String.Format("SELECT COUNT(Username) FROM Users WHERE Username = '{0}'", str_Username);
                DataTable dt_UserCount = SQLHelper.GetDataTable(sql_UserCount);
                if (!dt_UserCount.Rows[0][0].Equals(0))
                {
                    // 判断密码是否正确
                    string sql_Password = String.Format("SELECT Password FROM Users WHERE Username = '{0}'", str_Username);
                    DataTable dt_Password = SQLHelper.GetDataTable(sql_Password);
                    if (dt_UserCount.Rows[0][0].ToString().Equals(str_Password))
                    {
                        this.DialogResult = DialogResult.OK;
                    } else { MessageBox.Show("密码不正确" + dt_UserCount.Rows[0][0].ToString()); }
                } else { MessageBox.Show(String.Format("数据库中不存在【{0}】用户名", str_Username)); }

            }

            // 注册事件
            if ((Button)sender == btn_signUp)
            {
                new FormSignUp().Show();
                return;
            }

            // 重置密码
            if ((Button)sender == btn_reset)
            {
                new FormReset().Show();
                return;
            }

            // 退出事件
            if ((Button)sender == btn_exit)
            {
                Application.Exit();
            }
        }

        private void Buttons_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Black;
            (sender as Button).ForeColor = Color.White;
        }

        private void Buttons_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.White;
            (sender as Button).ForeColor = Color.Black;
        }


        #region // 窗体移动
        private int ax, ay;  // 定义两个变量存储鼠标的横纵坐标
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            ax = e.X;
            ay = e.Y;
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left = this.Left + (e.X - ax);
                this.Top = this.Top + (e.Y - ay);
            }
        } 
        #endregion

    }
}
