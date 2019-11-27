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
    public partial class FSignUp : Form
    {
        public FSignUp()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string strUsername = tbx_Username.Text,
                   strPassword = tbx_Password.Text,
                   strRepassword = tbx_RePassword.Text;
            if (strUsername == "" ||
                    strPassword == "" ||
                    strRepassword == "")
            { MessageBox.Show("信息填写不能为空"); return; }
            if (strPassword != strRepassword)
            { MessageBox.Show("两次输入的密码不一致"); return; }

            // 判断用户名是否存在
            using (DataTable dt = MyUtils.SQL.GetDataTable(
               String.Format("SELECT COUNT(UserName) FROM TBUser WHERE UserName = '{0}'", strUsername)
            )) {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(String.Format("数据库中已存在【{0}】用户名", strUsername));
                    return;
                }
            }
            // 插入用户名和密码
            if (MyUtils.SQL.CommandSQL(
                String.Format("INSERT INTO TBUser (UserName, UserPassword) VALUES ('{0}', '{1}')", strUsername, strPassword)
            ) == 1)
            { MessageBox.Show("用户注册成功"); }
            else
            { MessageBox.Show("用户注册失败"); }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
