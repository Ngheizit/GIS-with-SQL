using System;
using System.Collections.Generic;
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

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using System.Data;

namespace StudentsManagement.WxzForms
{
    /// <summary>
    /// FAddStudent.xaml 的交互逻辑
    /// </summary>
    public partial class FAddStudent : Window
    {
        public FAddStudent()
        {
            InitializeComponent();
        }
        public void SetModify(IPoint point, string id, string sid, string sname, string ssex, string sbirth, string shome)
        {
            this.lb_title.Content = String.Format("修改学生(ID:{0})信息", id);
            this.tbx_Location.Text = String.Format("{0} {1}", point.X, point.Y);
            this.id = id;
            this.m_pPoint = point;
            WxzUtils.Ae.DrawPoint(point);
            this.m_home = shome;
            this.tbx_SID.Text = sid;
            this.tbx_SNAME.Text = sname;
            this.tbx_SSEX.Text = ssex;
            this.tbx_SBIRTH.Text = sbirth;
            this.tbx_HOME.Text = shome;
            this.isReady2Add = false;
        }
        public void SetAdd()
        {
            SetTextNull(tbx_HOME);
            SetTextNull(tbx_Location);
            SetTextNull(tbx_SBIRTH);
            SetTextNull(tbx_SID);
            SetTextNull(tbx_SNAME);
            SetTextNull(tbx_SSEX);
            this.lb_title.Content = "添加学生信息";
            this.isReady2Add = true;
        }

        private IPoint m_pPoint;
        public IPoint Point
        {
            get { return this.m_pPoint; }
            set { 
                this.m_pPoint = value;
                tbx_Location.Text = String.Format("{0}, {1}", m_pPoint.X, m_pPoint.Y);
            }
        }
        private string m_home;
        public string Home
        {
            get { return this.m_home; }
            set { 
                this.m_home = value;
                tbx_HOME.Text = m_home;
            }
        }
        public event Update updateDatGrid;
        private bool isReady2Add;
        private string id;

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void btn_SelectLocation_Click(object sender, RoutedEventArgs e)
        {
            bool isAdding = (WxzUtils.Ae.IsAddingStudent = !WxzUtils.Ae.IsAddingStudent);
            if (isAdding)
            {
                this.WindowState = WindowState.Minimized;
                WxzUtils.Ae.SetMapC2MouseStyle(esriControlsMousePointer.esriPointerCrosshair);
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            WxzUtils.Ae.DeleteAllElements();
            SetTextNull(tbx_HOME);
            SetTextNull(tbx_Location);
            SetTextNull(tbx_SBIRTH);
            SetTextNull(tbx_SID);
            SetTextNull(tbx_SNAME);
            SetTextNull(tbx_SSEX);
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void SetTextNull(DevExpress.Xpf.Editors.TextEdit td)
        {
            td.Text = "";
        }
        private void SetTextNull(ComboBox td)
        {
            td.Text = "";
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            string strSID = tbx_SID.Text,
                   strSNAME = tbx_SNAME.Text,
                   strSSEX = tbx_SSEX.Text,
                   strSBIRTH = tbx_SBIRTH.Text,
                   strSHOME = tbx_HOME.Text;
            if (strSHOME == "" || tbx_Location.Text == "" || strSBIRTH == "" || strSID == "" || strSNAME == "" || strSSEX == "")
            {
                MessageBox.Show("学生信息未填写完成");
                return;
            }
            if (isReady2Add) // 添加学生信息
            {
                if (WxzUtils.Sql.CommandSQL(
                        String.Format("INSERT INTO  StudentInfo (SID,SName,SSex,SBirth,SHome) VALUES ('{0}','{1}','{2}','{3}','{4}')"
                                      , strSID, strSNAME, strSSEX, strSBIRTH, strSHOME)) != 0)
                {
                    DataTable dt = WxzUtils.Sql.GetDataTable(String.Format("SELECT Id FROM StudentInfo WHERE SID = '{0}' AND SName = '{1}'",
                        strSID, strSNAME));
                    string strId = dt.Rows[0][0].ToString();
                    WxzUtils.Ae.AddStudent(m_pPoint, strId, strSID, strSNAME, strSSEX, strSBIRTH, strSHOME);
                    updateDatGrid();

                    MessageBox.Show(String.Format("学生【{0}】添加成功", strSNAME));
                }
            }
            else // 修改学生信息
            {
                if (WxzUtils.Sql.CommandSQL(
                        String.Format("UPDATE StudentInfo SET SID = '{0}', SName = '{1}', SSex = '{2}', SBirth = '{3}', SHome = '{4}' WHERE  Id = '{5}'",
                                        strSID, strSNAME, strSSEX, strSBIRTH, strSHOME, id)) != 0)
                {
                    WxzUtils.Ae.ModifyStudent(m_pPoint, id, strSID, strSNAME, strSSEX, strSBIRTH, strSHOME);
                    updateDatGrid();
                    MessageBox.Show(String.Format("学生【ID:{0}】修改成功", id));
                }
            }
            SetTextNull(tbx_HOME);
            SetTextNull(tbx_Location);
            SetTextNull(tbx_SBIRTH);
            SetTextNull(tbx_SID);
            SetTextNull(tbx_SNAME);
            SetTextNull(tbx_SSEX);
            this.Hide();
        }

    }
}
