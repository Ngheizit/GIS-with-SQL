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
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SystemUI;

namespace StudentManagementSystem
{
    public delegate void CloseWaitForm();

    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private int m_pLocationInfoUnit; // 0 → 米; 1 → 十进制度;
        private Forms.FormHawkEye f_HawkEye;
        private IHookHelper m_pHookHelper;
        private Forms.FormEditStudent f_EditStudent;
        private Forms.FormStudentInfo f_StudentInfo;

        public FormMain()
        {
            InitializeComponent();
            this.m_pMapC2 = axMapControl_Main.Object as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
            this.m_pLocationInfoUnit = 0;
            this.m_pHookHelper = new HookHelperClass() { 
                Hook = m_pMapC2
            };
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AeUtils.SetMapControl(m_pMapC2);
            AeUtils.SetMapDocument(m_pMapDoc);
            AeUtils.LoadMxd(Application.StartupPath + @"\Data\Map.mxd");
            AeUtils.CloseWaitForm += CloseWaitForm;

            ShowMapScaleInfo();

            SqlUtils.UpdataDatabaseView(dataGridView_Main);
        }

        #region → 自定义方法
        private void ShowLocationInfo(IMapControlEvents2_OnMouseMoveEvent e)
        {
            IPoint pPoint = new PointClass()
            {
                X = e.mapX,
                Y = e.mapY,
                SpatialReference = m_pMapC2.SpatialReference
            };
            string unit = m_pMapC2.MapUnits.ToString().Substring(4);
            switch (this.m_pLocationInfoUnit)
            {
                case 0:
                    tbx_LocationInfo.Text = AeUtils.GetLocationInfo(pPoint, unit);
                    break;
                case 1:
                    tbx_LocationInfo.Text = AeUtils.GetLocationInfo(pPoint);
                    break;
            }
        }
        private void ShowMapScaleInfo()
        {
            tbx_MapScaleInfo.Text = String.Format("1:{0}", m_pMapC2.MapScale);
        }
        private void CloseWaitForm()
        {
            splashScreenManager1.CloseWaitForm();
        }
        private void OpenWaitForm()
        {
            splashScreenManager1.ShowWaitForm();
        }
        #endregion


        #region → AxMapControl 控件事件集
        private void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                AeUtils.Pan();
            }
            else if (e.button == 1 && f_EditStudent != null && !f_EditStudent.IsDisposed && f_EditStudent.IsGettingPoint)
            {
                IPoint pPoint = new PointClass() { 
                    X = e.mapX, Y = e.mapY, SpatialReference = m_pMapC2.SpatialReference
                };
                f_EditStudent.Point = pPoint;
                f_EditStudent.IsGettingPoint = false;
                f_EditStudent.WindowState = FormWindowState.Normal;
                AeUtils.SetMousePointer(esriControlsMousePointer.esriPointerArrow);
                f_EditStudent.Home = AeUtils.GetClickHome(pPoint); // 获取点击位置的省份
            }
            else if (e.button == 1 && m_pMapC2.MousePointer == esriControlsMousePointer.esriPointerIdentify)
            {
                
                if (f_StudentInfo == null || f_StudentInfo.IsDisposed)
                {
                    f_StudentInfo = new Forms.FormStudentInfo();
                    f_StudentInfo.SetInfo(AeUtils.SelectStudentFeatureByPoint(new PointClass() {
                        X = e.mapX,
                        Y = e.mapY,
                        SpatialReference = m_pMapC2.SpatialReference
                    }));
                    try
                    {
                        f_StudentInfo.Show();
                    }
                    catch { }
                }
                else
                {
                    f_StudentInfo.SetInfo(AeUtils.SelectStudentFeatureByPoint(new PointClass() {
                        X = e.mapX,
                        Y = e.mapY,
                        SpatialReference = m_pMapC2.SpatialReference
                    }));
                }
            }
        }
        private void axMapControl_Main_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            ShowLocationInfo(e); // 鼠标所在坐标显示
        }
        private void axMapControl_Main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            ShowMapScaleInfo(); // 地图比例尺显示
            if (f_HawkEye != null && !f_HawkEye.IsDisposed)
            {
                f_HawkEye.DrawExtent(); 
            }
        }
        #endregion


        #region → 坐标单位显示 事件集
        private void 米ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_pLocationInfoUnit = 0;
        }
        private void 十进制度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_pLocationInfoUnit = 1;
        } 
        #endregion


        #region → 导航栏 地图导航 事件集
        private void btn_Default_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.DefaultTool(); // 默认
        }
        private void btn_Pan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.PanTool(); // 漫游
        }
        private void btn_FullExtent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.FullExtent(); // 全图
        }
        private void btn_ZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.ZoomInTool(); // 拉框放大
        }
        private void btn_ZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.ZoomOutTool(); // 拉框缩小
        }
        private void btn_ZoomInFiexd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.ZoomInFiexd(); // 比例放大
        }
        private void btn_ZoomOutFiexd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.ZoomOutFiexd(); // 比例缩小
        }
        private void btn_HawkEye_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_HawkEye != null && !f_HawkEye.IsDisposed)
            {
                f_HawkEye.Show();
            }
            else
            {
                f_HawkEye = new Forms.FormHawkEye(m_pHookHelper);
                f_HawkEye.Show();
            }
        }
        #endregion
        #region → 导航栏 系统操作 事件集
        private void btn_SaveMxd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.SaveMxd();
        }
        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        } 
        #endregion
        #region → 导航栏 用户信息 事件集
        private void btn_PersonalWebsite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ngheizit.fun/");
        }
        private void btn_Github_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Ngheizit");
        } 
        #endregion


        #region → 导航栏 学生信息编辑 事件集
        private void btn_AddStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_EditStudent == null || f_EditStudent.IsDisposed)
            {
                f_EditStudent = new Forms.FormEditStudent();
                f_EditStudent.UpdataDatabaseView += () => {
                    SqlUtils.UpdataDatabaseView(dataGridView_Main);
                };
                f_EditStudent.Show();
            }
            else
            {
                f_EditStudent.Show();
            }
        }
        private void btn_EditStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strId = dataGridView_Main.SelectedRows[0].Cells[0].Value.ToString(),
                   strSId = dataGridView_Main.SelectedRows[0].Cells[1].Value.ToString(),
                   strSName = dataGridView_Main.SelectedRows[0].Cells[2].Value.ToString(),
                   strSSex = dataGridView_Main.SelectedRows[0].Cells[3].Value.ToString(),
                   strSBirth = dataGridView_Main.SelectedRows[0].Cells[4].Value.ToString(),
                   strSHome = dataGridView_Main.SelectedRows[0].Cells[5].Value.ToString();
            IPoint pPoint = AeUtils.GetPointFromId(strId);
            if (f_EditStudent == null || f_EditStudent.IsDisposed)
            {
                f_EditStudent = new Forms.FormEditStudent(pPoint, strId, strSId, strSName, strSSex, strSBirth, strSHome);
                f_EditStudent.UpdataDatabaseView += () => {
                    SqlUtils.UpdataDatabaseView(dataGridView_Main);
                };
                f_EditStudent.Show();
            }
            else
            {
                f_EditStudent.Show();
            }

        }
        private void btn_DeleteStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_EditStudent == null || f_EditStudent.IsDisposed)
            {
                string strSName = dataGridView_Main.SelectedRows[0].Cells[2].Value.ToString(),
                       strId = dataGridView_Main.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageBox.Show(String.Format("是否删除学生【{0};Id:{1}】", strSName, strId), "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SqlUtils.DeleteStudent(strId))
                    {
                        AeUtils.DeleteStudent(strId);
                        MessageBox.Show(String.Format("学生【{0};Id:{1}】删除成功", strSName, strId));
                        SqlUtils.UpdataDatabaseView(dataGridView_Main);
                    }
                }
            }
            else
            {
                MessageBox.Show("正在添加或编辑学生信息中", "无法删除学生信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 
        #endregion
        #region → 导航栏 学生信息查询 事件集
        private void btn_SearchStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.SetMousePointer(esriControlsMousePointer.esriPointerIdentify);
        }
        private void btn_SeachSelected_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_StudentInfo == null || f_StudentInfo.IsDisposed)
            {
                f_StudentInfo = new Forms.FormStudentInfo();
                f_StudentInfo.SetInfo(dataGridView_Main.SelectedRows);
                f_StudentInfo.Show();
            }
            else
            {
                f_StudentInfo.SetInfo(dataGridView_Main.SelectedRows);
                f_StudentInfo.Show();
            }

        }
        private void btn_ZoomToSelectedStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.ZoomToSelectStudent();
        }
        private void btn_ClearSelection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        } 
        #endregion
        #region → 导航栏 学生信息分析 事件集
        private void btn_Nearly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Forms.FormNearly().Show();
        }
        private void btn_Center_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IPoint pPoint = MeasureUtils.GetCenterPoint(AeUtils.GetStudentList());
            string LocationPRJ = String.Format("投影坐标：({0}, {1})", pPoint.X, pPoint.Y);
            AeUtils.DrawCenterPoint(pPoint);
            IPoint pPointCGS = AeUtils.PRJtoGCS(pPoint);
            string LocationCGS = String.Format("地理坐标：({0}, {1})", pPointCGS.X, pPointCGS.Y);
            MessageBox.Show(String.Format("平均中心\n{0}\n{1}", LocationPRJ, LocationCGS));
        }
        private void btn_Taisen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenWaitForm();
            AeUtils.GetTysonPolygon();
        }
        private void btn_distributed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btn_ClearAnalysis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AeUtils.DeleteAllMapElement();
            m_pMapC2.Map.DeleteLayer(AeUtils.GetFeatureLayerByName("tyson"));
        }
        #endregion


        #region → 导航栏 用户管理事件集
        private void btn_ResetUsername_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btn_ResetPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btn_DeleteUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btn_ChangeUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        } 
        #endregion


        private void dataGridView_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (f_StudentInfo != null && !f_StudentInfo.IsDisposed)
                f_StudentInfo.SetInfo(dataGridView_Main.SelectedRows);
        }













    }
}
