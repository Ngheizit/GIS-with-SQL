using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using DevExpress.Utils;
using System.Threading;

namespace XizheGIS
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string _username, _id;
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;

        public FormMain(string id, string username)
        {
            InitializeComponent();
            this._username = username;
            this._id = id;
            this.m_pMapC2 = axMapControl_Main.GetOcx() as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
        }
        private void ShowUserInfo()
        {
            tbx_UserInfo.Caption = String.Format("{0}: {1}", this._id, this._username);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ShowUserInfo();
            MyUtils.AE.SetMapControl(m_pMapC2);
            MyUtils.AE.SetMapDocument(m_pMapDoc);
            MyUtils.AE.SetPageLayout(axPageLayoutControl_Main);
        }

        #region → 开始菜单按钮事件集
        private void btn_OpenMxd_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = "打开地图文档",
                Filter = "地图文档 (*.mxd)|*.mxd",
                InitialDirectory = Application.StartupPath
            };
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                string mxdPath = ofg.FileName;
                if (!MyUtils.AE.MxdManagement.Load(mxdPath))
                {
                    MessageBox.Show(String.Format("地图文档打开失败\n{0}", mxdPath));
                }
            }
        }
        private void btn_ResetPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new MyForm.FReset(this._username).Show();
        }
        private void btn_SignOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MyUtils.System.ReLoign();
        }
        private void btn_SaveMxd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MyUtils.AE.MxdManagement.Save())
                MessageBox.Show("地图文档保存成功");
        }
        private void btn_SaveAsMxd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog() { 
                Title = "选择文档保存路径",
                Filter = "地图文档 (*.mxd)|*.mxd",
                InitialDirectory = Application.StartupPath
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                string newPath = sfg.FileName;
                if (MyUtils.AE.MxdManagement.SaveAs(newPath))
                    MessageBox.Show("地图文档另存为成功");
            }
        }
        private void btn_FullExtent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_pMapC2.Extent = m_pMapC2.FullExtent;
        }
        #endregion        
        #region → 后台页按钮事件集
        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Application.Exit();
        } 
        #endregion

        #region → MouseMove事件
        private void axMapControl_Main_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            tbx_LocationInfo.Caption =
                String.Format("{0} {1} {2}", e.mapX.ToString(".###"), e.mapY.ToString(".###"), m_pMapC2.MapUnits.ToString().Substring(4));
        }
        private void axPageLayoutControl_Main_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            tbx_LocationInfo.Caption =
                String.Format("{0} {1} {2}", e.pageX.ToString(".###"), e.pageY.ToString(".###"), axPageLayoutControl_Main.Page.Units.ToString().Substring(4));
        } 
        #endregion

        #region → 数据视图与布局视图的同步
        private void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page == tabPage_DataView)
            {
                axTOCControl1.SetBuddyControl(axMapControl_Main);
            }
            else if (e.Page == tabPage_LayoutView)
            {
                axTOCControl1.SetBuddyControl(axPageLayoutControl_Main);
            }
        }
        private void axMapControl_Main_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            MyUtils.AE.CopyMapToLayoutView();
        } 
        #endregion

        #region → MouseDown事件
        private void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
                MyUtils.AE.Pan();
        }
        private void axPageLayoutControl_Main_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 4)
                MyUtils.AE.PagePan();
        }
        #endregion

        private void btn_SelectPythonExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = "选择python.exe可执行文件",
                Filter = "可执行文件 (*.exe)|*.exe"
            };
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                tbx_PythonExe.Text = ofg.FileName;
            }
        }

        private void btn_SelectPyFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog()
            {
                Title = "选择python脚本文件",
                Filter = "python脚本文件 (*.py)|*.py"
            };
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                tbx_PyFile.Text = ofg.FileName;
            }
        }

        private void btn_RunPy_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();

            MyUtils.Py.RunPy(tbx_PyFile.Text, tbx_PythonExe.Text);

            splashScreenManager1.CloseWaitForm();
        }








    }
}
