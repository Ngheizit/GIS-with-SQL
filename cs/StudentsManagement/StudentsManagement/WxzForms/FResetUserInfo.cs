using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsManagement.WxzForms
{
    public partial class FResetUserInfo : Form
    {
        private string _id;
        public event UpdateStr update;

        public FResetUserInfo(bool isNewName, string id)
        {
            InitializeComponent();
            this._id = id;
            if (isNewName)
            {
                this.Size = new Size(255, 87);
                group_NewName.Visible = true;
                group_NewPassword.Visible = false;
                this.Text = "更改用户名";
            }
            else
            {
                this.Size = new Size(255, 147);
                group_NewName.Visible = false;
                group_NewPassword.Visible = true;
                this.Text = "修改密码";
            }
        }

        private void btn_NewUName_Ok_Click(object sender, EventArgs e)
        {
            string strNewUName = tbx_NewUName.Text;
            if (strNewUName == "")
            {
                MessageBox.Show("信息为填写完整", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (DataTable dt = WxzUtils.Sql.GetDataTable(
                String.Format("SELECT COUNT(UName) FROM UserInfo WHERE UName = '{0}'", strNewUName)))
            {
                if (dt.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(String.Format("当前用户名【{0}】已存在", strNewUName), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (WxzUtils.Sql.CommandSQL(
                String.Format("UPDATE UserInfo SET UName = '{0}' WHERE Id = '{1}'", strNewUName, _id)
                ) == 1)
            {
                MessageBox.Show("用户名修改成功");
                update(strNewUName);
            }
        }

        private void btn_NewPassword_Ok_Click(object sender, EventArgs e)
        {
            string strOldPassword = tbx_OldPassword.Text,
                   strNewPassword = tbx_NewPassword.Text,
                   strReNewPassword = tbx_ReNewPassword.Text;
            if (strOldPassword == "" || strNewPassword == "" || strReNewPassword == "")
            {
                MessageBox.Show("信息为填写完整", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (strNewPassword != strReNewPassword)
            {
                MessageBox.Show("两次输入密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (DataTable dt = WxzUtils.Sql.GetDataTable(
                String.Format("SELECT UPassword FROM UserInfo WHERE Id = '{0}'", _id)    
            ))
            {
                if (dt.Rows[0][0].ToString() != strOldPassword)
                {
                    MessageBox.Show("旧密码输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (WxzUtils.Sql.CommandSQL(
                String.Format("UPDATE UserInfo SET UPassword = '{0}' WHERE Id = '{1}'", strNewPassword, _id)
            ) == 1)
            {
                MessageBox.Show("密码修改成功");
            }
        }
    }
}
