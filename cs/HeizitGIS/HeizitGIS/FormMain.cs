using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace HeizitGIS
{
    public partial class FormMain : Form
    {
        public FormMain(string id, string username)
        {
            InitializeComponent();
            tbx_info_ID.Text = id;
            tbx_info_Username.Text = username;
        }

        private void Button_Info_Click(object sender, EventArgs e)
        {
            // 修改密码
            if ((Button)sender == btn_UpdatePassword)
            {
                new FormReset(tbx_info_Username.Text).Show();
                return;
            }

            // 退出登录
            if ((Button)sender == btn_exit)
            {
                ReLoign();
            }
        }
        
        public static void ReLoign()
        {
            Application.ExitThread();
            Thread thtmp = new Thread(new ParameterizedThreadStart(Run));
            object appName = Application.ExecutablePath;
            Thread.Sleep(1);
            thtmp.Start(appName);
        }
        private static void Run(Object appName)
        {
            Process ps = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = appName.ToString()
                }
            };
            ps.Start();
        }
    }
}
