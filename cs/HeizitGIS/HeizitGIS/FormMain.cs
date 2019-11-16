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
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private string _username;
        private int _id;
        private ToolbarMenu m_pToolbarMenu;


        public FormMain(int id, string username)
        {
            InitializeComponent();
            tbx_info_ID.Text = id.ToString();
            tbx_info_Username.Text = username;

            this._id = id;
            this._username = username;
            this.m_pMapC2 = axMapControl_main.GetOcx() as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            InitTOCControl();
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
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = "打开地图文档对话框",
                Filter = "地图文档 (*.mxd)|*.mxd",
                InitialDirectory = Application.StartupPath
            };
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                string mxdPath = ofg.FileName;
                if (m_pMapC2.CheckMxFile(mxdPath))
                {
                    m_pMapDoc.Open(mxdPath); // or m_pMapC2.LoadMxFile(mxdPath);
                    m_pMapC2.Map = m_pMapDoc.Map[0];
                }
            }
        }
        private void 用户通信平台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfos f_infos = new FormInfos(_id);
            f_infos.Show();
        }
        private void 其他ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = String.Format("SELECT [Object-ID] FROM ViewMsgs WHERE ToID = {0} AND IsRead = 0", _id);
            DataTable dt = SQLHelper.GetDataTable(sql);
            int count = dt.Rows.Count;
            用户通信平台ToolStripMenuItem.Text = String.Format("用户通信平台(未处理信息: {0}条)", count);
        }
        #endregion


        #region → 鼠标响应事件集
        private void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
        }
        private void axMapControl_main_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            label_showLocation.Text = String.Format("{0}, {1} {2}", 
                                                    e.mapX.ToString(".###"), 
                                                    e.mapX.ToString(".###"), 
                                                    m_pMapC2.MapUnits.ToString().Substring(4));
        } 
        #endregion


        #region → 数据视图与布局视图同步功能事件集
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) //  数据视图
            {
                axTOCControl_main.SetBuddyControl(axMapControl_main);
            }
            else // 布局视图
            {
                axTOCControl_main.SetBuddyControl(axPageLayoutControl_main);
            }
        }
        private void axMapControl_main_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            // 范围同步
            IActiveView pActiveView = axPageLayoutControl_main.ActiveView.FocusMap as IActiveView;
            pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds = m_pMapC2.Extent;
            pActiveView.Refresh();
            // 内容同步
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            object pCopyMap = pObjectCopy.Copy(m_pMapC2.Map);
            object pOverwriteMap = pActiveView;
            pObjectCopy.Overwrite(pCopyMap, pOverwriteMap);
        }
        #endregion


        #region → 关闭窗体事件
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否保存保存地图文档", "程序准备关闭", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    m_pMapDoc.Save();
                    e.Cancel = false;
                }
                catch
                {
                    MessageBox.Show("当前地图文档无法保存", "错误信息");
                    e.Cancel = true;
                }
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


        #region → 鹰眼功能事件集
        private void btn_Hawkeye_Click(object sender, EventArgs e)
        {
            if (btn_Hawkeye.Text == "↙") // 开启鹰眼
            {
                axMapControl_hawkeye.Visible = true;
                btn_Hawkeye.Text = "↗";
                Hawkeye_AddMap();
            }
            else // 关闭鹰眼
            {
                axMapControl_hawkeye.Visible = false;
                btn_Hawkeye.Text = "↙";
            }
        }
        private void Hawkeye_AddMap()
        {
            axMapControl_hawkeye.ClearLayers();
            IMap pMap = m_pMapC2.Map;
            for (int i = pMap.LayerCount - 1; i >= 0; i--)
            {
                axMapControl_hawkeye.AddLayer(pMap.get_Layer(i));
            }
            axMapControl_hawkeye.Extent = axMapControl_hawkeye.FullExtent;
            Hawkeye_DrawExtent(m_pMapC2.Extent);
        }
        private void Hawkeye_DrawExtent(IEnvelope envelope)
        {
            IGraphicsContainer pGC = axMapControl_hawkeye.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            IElement pElement = new RectangleElementClass()
            {
                Geometry = envelope,
                Symbol = AeUtils.CreateSimpleFillSymbol(
                    AeUtils.CreateRgbColor(), // 填充颜色 - 透明
                    AeUtils.CreateRgbColor(255, 0, 0), // 边框颜色 - 红色
                    2 // 边框大小
                )
            };
            pGC.AddElement(pElement, 0);
            axMapControl_hawkeye.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        private void axMapControl_main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            if (axMapControl_hawkeye.Visible)
            {
                Hawkeye_DrawExtent(e.newEnvelope as IEnvelope);
            }
        }
        private void axMapControl_hawkeye_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                m_pMapC2.CenterAt(new PointClass() {
                    X = e.mapX,
                    Y = e.mapY
                });
            }
            else if (e.button == 2)
            {
                IEnvelope pEnv = axMapControl_hawkeye.TrackRectangle();
                m_pMapC2.Extent = pEnv;
            }
        }
        #endregion

        #region → TOCC控件HitTest()事件
        private void InitTOCControl()
        {
            object[] cmds = new object[] { 
                new AeCmd.ShowAttributeTable(),
                new AeCmd.ZoomToLayer()
            };
            m_pToolbarMenu = new ToolbarMenu();
            for (int i = 0; i < cmds.Length; i++)
                m_pToolbarMenu.AddItem(cmds[i]);
            m_pToolbarMenu.SetHook(m_pMapC2);
        }
        private void axTOCControl_main_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object index = new object();
            object other = new object();
            esriTOCControlItem item = new esriTOCControlItem();
            axTOCControl_main.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if (e.button == 2 && item == esriTOCControlItem.esriTOCControlItemLayer)
            { 
                (m_pMapC2 as IMapControl4).CustomProperty = layer;
                m_pToolbarMenu.PopupMenu(e.x, e.y, axTOCControl_main.hWnd);
            }
        } 
        #endregion

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







        
    }
}
