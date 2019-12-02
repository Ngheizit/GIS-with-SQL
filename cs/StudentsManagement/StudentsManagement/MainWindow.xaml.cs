using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using System.Data;
using ESRI.ArcGIS.Geodatabase;

namespace StudentsManagement
{
    public delegate void Update();
    public delegate void UpdateStr(string str);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        private AxMapControl axMapControl_Main;
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private WxzForms.FAddStudent f_AddStudent;
        private WxzForms.FStudentInfo f_StudentInfo;

        private string _id, _name;

        public MainWindow(string id, string name)
        {
            InitializeComponent();
            this.axMapControl_Main = new AxMapControl();
            mapHost.Child = axMapControl_Main;

            this._id = id;
            this._name = name;
            tbx_UserInfo.Content = String.Format("🧛‍{0}（ID：{1}）", _name, _id);
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.m_pMapC2 = axMapControl_Main.GetOcx() as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
            this.axMapControl_Main.OnMouseDown += axMapControl_Main_OnMouseDown;
            this.axMapControl_Main.OnMouseMove += axMapControl_Main_OnMouseMove;
            this.axMapControl_Main.OnExtentUpdated += axMapControl_Main_OnExtentUpdated;
            this.f_AddStudent = new WxzForms.FAddStudent();
            f_AddStudent.updateDatGrid += new Update(UpdateDataTable);
            this.f_StudentInfo = new WxzForms.FStudentInfo();
            


            UpdateDataTable();

            WxzUtils.Ae.SetMapControl(m_pMapC2);
            WxzUtils.Ae.SetMapDocument(m_pMapDoc);
            WxzUtils.Ae.LoadMxd("Map.mxd");
        }
        #region → 地图基本操作
        void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                WxzUtils.Ae.Pan();
            }
            else if (e.button == 1 && WxzUtils.Ae.IsAddingStudent)
            {
                IPoint pPoint = new PointClass() { 
                    X = e.mapX, Y = e.mapY
                };
                WxzUtils.Ae.DrawPoint(pPoint);
                WxzUtils.Ae.IsAddingStudent = false;

                f_AddStudent.Point = pPoint;
                f_AddStudent.Home = GetClickLocation(pPoint);

                f_AddStudent.WindowState = WindowState.Normal;
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            else if (e.button == 1 && m_pMapC2.MousePointer == esriControlsMousePointer.esriPointerIdentify)
            {
                WxzUtils.Ae.SelectStudentByPoint(new PointClass() { 
                    X = e.mapX, Y = e.mapY, SpatialReference = m_pMapC2.SpatialReference
                });
                string id = WxzUtils.Ae.GetSelectStudentId();
                for (int i = 0; i < DataGridView_Student.Items.Count; i++)
                {
                    if ((DataGridView_Student.Items[i] as DataRowView)[0].ToString() == id)
                    {
                        DataGridView_Student.SelectedIndex = i;
                        ShowStudentInfo();
                        return;
                    }
                }

            }
        }
        void axMapControl_Main_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            string lonlatUnit = String.Format("{0} {1} {2}", e.mapX.ToString(".###"), e.mapY.ToString(".###"), m_pMapC2.MapUnits.ToString().Substring(4));
            
            tbx_LocationInfo.Content = lonlatUnit;
        }
        void axMapControl_Main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            string MapScale = String.Format("比例尺：1:{0}", m_pMapC2.MapScale);
            tbx_MapScaleInfo.Content = MapScale;
        }


        private void btn_Save_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (WxzUtils.Ae.SaveMxd())
            {
                MessageBox.Show("地图文档保存成功");
            }
        }
        private void btn_FullExtent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            m_pMapC2.Extent = m_pMapC2.FullExtent;
        }
        private void btn_ZoomIn_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            WxzUtils.Ae.Zoom(1.1);
        }
        private void btn_ZoomOut_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            WxzUtils.Ae.Zoom(0.9);
        } 
        #endregion

        private string GetClickLocation(IPoint point)
        {
            string result = "";
            IFeatureLayer pFeatureLayer = WxzUtils.Ae.GetFeatureLayerByName("BOUA_PJ");
            ISpatialFilter pSpatialFilter = new SpatialFilterClass() {
                Geometry = point,
                SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
            };
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(pSpatialFilter as IQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            if (pFeature != null)
                result = pFeature.get_Value(pFeature.Fields.FindField("NAME")).ToString();
            return result;
        }


        #region → 学生信息可视化
        private void UpdateDataTable()
        {
            DataTable dt = WxzUtils.Sql.GetDataTable("SELECT * FROM StudentInfo");
            DataGridView_Student.ItemsSource = dt.DefaultView;
        }
        private void DataGridView_Student_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "yyyy/MM/dd";
        }
        private void ShowStudentInfo()
        {
            DataRowView row = (DataRowView)DataGridView_Student.SelectedItem;
            if (row == null)
                return;
            string sid = row[1].ToString();
            string sname = row[2].ToString();
            string ssex = row[3].ToString();
            string sbirth = row[4].ToString().Split(' ')[0];
            string shome = row[5].ToString();
            if (f_StudentInfo.IsDisposed)
            {
                f_StudentInfo = new WxzForms.FStudentInfo();
            }
            f_StudentInfo.SetInfo(sid, sname, ssex, sbirth, shome);
            f_StudentInfo.Show();
        }
        #endregion

        #region → 学生信息增删改
        private void btn_AddStudent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            f_AddStudent.SetAdd();
            f_AddStudent.Show();
        }
        private void btn_ModifyStudent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
            if (DataGridView_Student.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)DataGridView_Student.SelectedItem;
                string id = row[0].ToString();
                string sid = row[1].ToString();
                string sname = row[2].ToString();
                string ssex = row[3].ToString();
                string sbirth = row[4].ToString().Split(' ')[0];
                string shome = row[5].ToString();
                IFeatureLayer pFeatureLayer = WxzUtils.Ae.GetFeatureLayerByName("Students");
                IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    if (pFeature.get_Value(pFeature.Fields.FindField("Id")).ToString() == id.ToString())
                    {
                        IPoint pPoint = pFeature.Shape as IPoint;
                        f_AddStudent.SetModify(pPoint, id, sid, sname, ssex, sbirth, shome);
                        f_AddStudent.Show();
                        return;
                    }
                    pFeature = pFeatureCursor.NextFeature();
                }
            }
            else
                MessageBox.Show("请选择需要修改的学生");
        }
        private void btn_DeleteStudent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            f_AddStudent.Hide();
            if (DataGridView_Student.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)DataGridView_Student.SelectedItem;
                string id = row[0].ToString();
                string sname = row[2].ToString();
                if (MessageBox.Show(String.Format("是否删除学生【{0}】", sname), "提醒", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (WxzUtils.Sql.CommandSQL(
                        String.Format("DELETE FROM StudentInfo WHERE Id= '{0}'", id)) != 0)
                    {
                        WxzUtils.Ae.DeleteStudent(id);
                        m_pMapC2.Refresh();
                        UpdateDataTable();
                        MessageBox.Show(String.Format("学生【{0}】删除成功", sname));
                    }
                    else
                        MessageBox.Show(String.Format("学生【{0}】删除失败", sname));
                }
            }
            else
                MessageBox.Show("请选择需要删除的学生");
        } 
        #endregion

        #region → 程序关闭事件
        private void ThemedWindow_Closed_1(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion


        #region → 学生管理 学生信息查询
        private void DataGridView_Student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridView_Student.SelectedItem;
            if (row != null)
            {
                string id = row[0].ToString();
                WxzUtils.Ae.SelectStudentById(id);

                if (f_StudentInfo.IsDisposed)
                {
                    f_StudentInfo = new WxzForms.FStudentInfo();
                }
                string sid = row[1].ToString();
                string sname = row[2].ToString();
                string ssex = row[3].ToString();
                string sbirth = row[4].ToString().Split(' ')[0];
                string shome = row[5].ToString();
                f_StudentInfo.SetInfo(sid, sname, ssex, sbirth, shome);
            }
        }
        private void btn_Search_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerIdentify;
        }
        private void btn_ShowSelect_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ShowStudentInfo();
        }
        private void btn_ZoomToSelect_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            WxzUtils.Ae.ZoomToSelectedStudent();
        }
        private void btn_ClearSelect_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            m_pMapC2.Map.ClearSelection();
            m_pMapC2.Refresh();
        } 
        #endregion

        private void DataGridView_Student_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try {
                WxzUtils.Ae.ZoomToSelectedStudent();
            }
            catch{ }
        }


        private void UpdataUserInfo(string newUName)
        {
            this._name = newUName;
            tbx_UserInfo.Content = String.Format("🧛‍{0}（ID：{1}）", _name, _id);
        }
        private void btn_NewUName_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            WxzForms.FResetUserInfo f_ResetUserInfo = new WxzForms.FResetUserInfo(true, _id);
            f_ResetUserInfo.update += UpdataUserInfo;
            f_ResetUserInfo.ShowDialog();
        }

        private void btn_NewUPassword_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            new WxzForms.FResetUserInfo(false, _id).ShowDialog();
        }

        

    }
}
