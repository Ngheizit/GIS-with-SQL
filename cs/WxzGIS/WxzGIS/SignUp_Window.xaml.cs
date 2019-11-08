using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WxzGIS
{
    /// <summary>
    /// Interaction logic for SignUp_Window.xaml
    /// </summary>
    public partial class SignUp_Window : Window
    {
        public SignUp_Window()
        {
            InitializeComponent();
        }

        #region 注册
        private void Btn_yes_Click(object sender, RoutedEventArgs e)
        {
            string str_Username = tbx_username.Text,
                   str_Password = tbx_password.Text,
                   str_rePassword = tbx_repassword.Text;
            
            // 信息不能为空
            if(str_Username == "" || str_Password == "" || str_rePassword == "")
            {
                MessageBox.Show("信息填写不能为空");
                return;
            }

            // 判断密码是否一致
            if(str_Password != str_rePassword)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }

            // 判断用户名是否存在
            DataTable dataTable = SQLHelper.GetDataTable(SQLHelper.SQL_SelectAll("Users", "Username", str_Username));
            if(dataTable.Rows.Count != 0)
            {
                MessageBox.Show(String.Format("用户名【{0}】已存在", str_Username));
                return;
            }

            // 插入用户名和密码
            if (SQLHelper.CommandSQL(SQLHelper.SQL_Insert("Users", "Username, Password", String.Format("'{0}','{1}'", str_Username, str_Password))) == 1)
            { MessageBox.Show("注册成功"); }
            else
            {  MessageBox.Show("注册失败"); }
        } 
        #endregion

        #region 关闭注册界面
        private void Btn_no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
        #endregion


    }
}
