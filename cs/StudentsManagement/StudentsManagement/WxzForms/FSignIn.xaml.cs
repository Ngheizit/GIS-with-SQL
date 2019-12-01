using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentsManagement.WxzForms
{
    /// <summary>
    /// FSignIn.xaml 的交互逻辑
    /// </summary>
    public partial class FSignIn : Window
    {
        public FSignIn()
        {
            InitializeComponent();
            Group_SignIn.Visibility = Visibility.Visible;
            Group_SignUp.Visibility = Visibility.Hidden;
        }

        private void HamburgerMenu_SelectedItemChanged_1(object sender, DevExpress.Xpf.WindowsUI.HamburgerMenuSelectedItemChangedEventArgs e)
        {
            string group = e.NewItem.ToString().Split(':')[1];
            if (group.Contains("登录"))
            {
                Group_SignIn.Visibility = Visibility.Visible;
                Group_SignUp.Visibility = Visibility.Hidden;
            }
            else if (group.Contains("注册"))
            {
                Group_SignIn.Visibility = Visibility.Hidden;
                Group_SignUp.Visibility = Visibility.Visible;
            }
            else if (group.Contains("退出"))
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        #region → 登录事件集
        private void btn_SignIn_Ok_Click(object sender, RoutedEventArgs e)
        {
            string strUsername = tbx_SignIn_Username.Text,
                   strPassword = tbx_SignIn_Password.Text;
            using (DataTable dt = WxzUtils.Sql.GetDataTable(
                String.Format("SELECT UPassword FROM UserInfo WHERE UName = '{0}'", strUsername)))
            {
                if (dt.Rows.Count == 0 || dt.Rows[0][0].ToString() != strPassword)
                {
                    MessageBox.Show("用户名或密码填写错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    new MainWindow().Show();
                    this.Close();
                }
            }
        }
        private void btn_SignIn_Clear_Click(object sender, RoutedEventArgs e)
        {
            tbx_SignIn_Username.Text = "";
            tbx_SignIn_Password.Text = "";
        } 
        #endregion

        #region → 注册事件集
        private void btn_SignUp_Ok_Click(object sender, RoutedEventArgs e)
        {
            string strUsername = tbx_SignUp_Username.Text,
                   strPassword = tbx_SignUp_Password.Text,
                   strRePassword = tbx_SignUp_RePassword.Text;
            if (strUsername == "" || strPassword == "" || strRePassword == "")
            {
                MessageBox.Show("信息未填写完整", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (strPassword != strRePassword)
            {
                MessageBox.Show("两次输入密码错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (DataTable dt = WxzUtils.Sql.GetDataTable(
                String.Format("SELECT COUNT(UName) FROM UserInfo WHERE UName = '{0}'", strUsername)))
            {
                if (dt.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(String.Format("当前用户名【{0}】已存在", strUsername), "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (WxzUtils.Sql.CommandSQL(
                String.Format("INSERT INTO UserInfo (UName, UPassword) VALUES ('{0}', '{1}')", strUsername, strPassword)) == 1)
            {
                MessageBox.Show(String.Format("用户【{0}】注册成功", strUsername), "完成");
            }
            else
            {
                MessageBox.Show("用户注册失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btn_SignUp_Clear_Click(object sender, RoutedEventArgs e)
        {
            tbx_SignUp_Username.Text = "";
            tbx_SignUp_Password.Text = "";
            tbx_SignUp_RePassword.Text = "";
        } 
        #endregion



 


    }
}
