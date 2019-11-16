using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeizitGIS
{
    public partial class FormInfos : Form
    {
        private int _fromID;
        private int[] _toIDs;

        public FormInfos(int id)
        {
            InitializeComponent();

            this._fromID = id;
        }

        private void FormInfos_Load(object sender, EventArgs e)
        {
            #region → 代码作用区域： 发送信息区
            string sql = String.Format("SELECT [Object-ID], Username FROM Users WHERE [Object-ID] != '{0}'", _fromID);
            DataTable dt = SQLHelper.GetDataTable(sql);
            int len = dt.Rows.Count;
            _toIDs = new int[len];
            for (int i = 0; i < len; i++)
            {
                _toIDs[i] = Convert.ToInt32(dt.Rows[i][0]);
                comboBox_toName.Items.Add(dt.Rows[i][1]);
            } 
            #endregion

            #region → 代码作用区域：信息库区
            // 检索接收到的信息
            sql = String.Format("SELECT FromName, SendTime, IsRead FROM ViewMsgs WHERE ToID = {0}", _fromID);
            dt = SQLHelper.GetDataTable(sql);
            
            #endregion

        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                int index = comboBox_toName.SelectedIndex;
                string msg = richTextBox1.Text;
                string time = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss");
                string sql = String.Format("INSERT INTO Msgs VALUES({0}, {1}, '{2}', '{3}', {4})",
                                            _fromID, _toIDs[index], msg, time, 0);
                if (msg == "")
                {
                    if (MessageBox.Show("发送内容为空，是否仍然发送", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }

                if (SQLHelper.CommandSQL(sql) == 1)
                {
                    MessageBox.Show("信息发送成功");
                }
                else
                {
                    MessageBox.Show("信息发送失败");
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("未选择发送至的用户");
            }
        }


    }
}
