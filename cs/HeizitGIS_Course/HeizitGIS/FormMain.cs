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
using System.Configuration;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace HeizitGIS
{
    public partial class FormMain : Form
    {
        private string _username;
        private int _id;


        public FormMain(int id, string username)
        {
            InitializeComponent();
            tbx_info_ID.Text = id.ToString();
            tbx_info_Username.Text = username;

            this.Text = ConfigurationManager.AppSettings["Title"];
            this._id = id;
            this._username = username;
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
             
        }


        #region → 用户操作（修改密码 and 退出登录）
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
        private static void Run(object appName)
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
        #endregion


        #region → 菜单栏事件集
        private void 打开地图文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 用户通信平台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfos f_infos = new FormInfos(_id);
            f_infos.Show();
        }
        private void 其他ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = String.Format("SELECT ID FROM ViewMsg WHERE ToUser = {0} AND IsRead = 0", _id);
            DataTable dt = SQLHelper.GetDataTable(sql);
            int count = dt.Rows.Count;
            用户通信平台ToolStripMenuItem.Text = String.Format("用户通信平台(未处理信息: {0}条)", count);
        }
        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((ToolStripMenuItem)sender == gitHubToolStripMenuItem)
            {
                System.Diagnostics.Process.Start("https://github.com/Ngheizit/GIS-with-SQL");
                return;
            }
            if ((ToolStripMenuItem)sender == websiteToolStripMenuItem)
            {
                System.Diagnostics.Process.Start("https://ngheizit.fun");
                return;
            }
        }
        private void 保存地图文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        #endregion


        


        #region → 关闭窗体事件
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否保存保存地图文档", "程序准备关闭", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else if (dr == DialogResult.No)
            {
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        } 
        #endregion

    }
}
