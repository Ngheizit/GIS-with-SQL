using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WxzGIS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SignIn_Window : Window
    {
        public SignIn_Window()
        {
            InitializeComponent();
            string licenseKsy = "runtimelite,1000,rud2630151591,none,PM0RJAY3FP20463EM070";
            Esri.ArcGISRuntime.ArcGISRuntimeEnvironment.SetLicense(licenseKsy);
            GdalConfiguration.ConfigureGdal();
            GdalConfiguration.ConfigureOgr();
            OSGeo.GDAL.Gdal.AllRegister();
        }


        #region // 登录事件
        private void btn_signIn_Click(object sender, RoutedEventArgs e)
        {
            string str_Username = tbx_username.Text,
                   str_Password = tbx_password.Text;
            // 判断用户名是否存在
            string sql_User = SQLHelper.SQL_SelectAll("Users", "Username", str_Username);
            DataTable dt__User = SQLHelper.GetDataTable(sql_User);
            if (dt__User.Rows.Count == 0)
            {
                MessageBox.Show(String.Format("用户名【{0}】不存在", str_Username));
                return;
            }

            // 判断密码是否正确
            if(dt__User.Rows[0][2].ToString() != str_Password)
            {
                MessageBox.Show("密码不正确");
                return;
            }
            MessageBox.Show("登录成功");
        } 
        #endregion


        #region // 注册事件
        private void btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            new SignUp_Window().Show();
        }
        #endregion

        #region 退出程序事件
        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            axMapView.IsAttributionTextVisible = false; // 去除脚注信息
            axMapView.Map = new Esri.ArcGISRuntime.Mapping.Map(Esri.ArcGISRuntime.Mapping.BasemapType.Topographic, 0, 180, 0);

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 100;
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(time);
        }

        private double lon = 180;
        private void time(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                axMapView.SetViewpointCenterAsync(0, lon--);
            }
            catch
            { }
        }

    }
}
