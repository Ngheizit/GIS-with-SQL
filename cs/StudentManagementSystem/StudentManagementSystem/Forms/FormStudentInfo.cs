using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using ESRI.ArcGIS.Geodatabase;

namespace StudentManagementSystem.Forms
{
    public partial class FormStudentInfo : DevExpress.XtraEditors.XtraForm
    {
        public FormStudentInfo()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public void SetInfo(DataGridViewSelectedRowCollection rows)
        {
            string strId = rows[0].Cells[0].Value.ToString(),
                   strSId = rows[0].Cells[1].Value.ToString(),
                   strSName = rows[0].Cells[2].Value.ToString(),
                   strSSex = rows[0].Cells[3].Value.ToString(),
                   strSBirth = rows[0].Cells[4].Value.ToString(),
                   strSHome = rows[0].Cells[5].Value.ToString();
            listBoxControl1.Items.Clear();
            listBoxControl1.Items.Add(String.Format("学号：{0}", strId));
            listBoxControl1.Items.Add(String.Format("姓名：{0}", strSName));
            listBoxControl1.Items.Add(String.Format("性别：{0}", strSSex));
            listBoxControl1.Items.Add(String.Format("生日：{0}", strSBirth.Split(' ')[0]));
            listBoxControl1.Items.Add(String.Format("家庭地址：{0}", strSHome));
        }
        public void SetInfo(IFeature feature)
        {
            if (feature == null)
            {
                this.Close();
                return;
            }
            string strId = feature.get_Value(feature.Fields.FindField("Id")).ToString(),
                   strSId = feature.get_Value(feature.Fields.FindField("SID")).ToString(),
                   strSName = feature.get_Value(feature.Fields.FindField("SNAME")).ToString(),
                   strSSex = feature.get_Value(feature.Fields.FindField("SSEX")).ToString(),
                   strSBirth = feature.get_Value(feature.Fields.FindField("SBIRTH")).ToString().Split(' ')[0],
                   strSHome = feature.get_Value(feature.Fields.FindField("SHOME")).ToString();
            listBoxControl1.Items.Clear();
            listBoxControl1.Items.Add(String.Format("学号：{0}", strId));
            listBoxControl1.Items.Add(String.Format("姓名：{0}", strSName));
            listBoxControl1.Items.Add(String.Format("性别：{0}", strSSex));
            listBoxControl1.Items.Add(String.Format("生日：{0}", strSBirth));
            listBoxControl1.Items.Add(String.Format("家庭地址：{0}", strSHome));
        }
    }
}