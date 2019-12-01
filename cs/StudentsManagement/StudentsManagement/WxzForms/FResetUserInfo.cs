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
        public FResetUserInfo(bool isNewName)
        {
            InitializeComponent();
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
    }
}
