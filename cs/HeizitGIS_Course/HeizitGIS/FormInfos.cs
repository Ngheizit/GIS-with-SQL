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
            string sql = String.Format("SELECT ID, Username FROM TBUser WHERE ID != '{0}'", _fromID);
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
            listView_receive.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView_receive.View = View.Details;
            listView_receive.FullRowSelect = true;
            listView_send.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView_send.View = View.Details;
            listView_send.FullRowSelect = true;
            AddHeader("发送人", listView_receive);
            AddHeader("发送时间", listView_receive, 120);
            AddHeader("是否已读", listView_receive);
            AddHeader("信息编号", listView_receive);
            AddHeader("发送至", listView_send);
            AddHeader("发送时间", listView_send, 120);
            AddHeader("对方是否已读", listView_send, 100);
            AddHeader("信息编号", listView_send);
            UpdateReceiveMsg();
            UpdateSendMsg();
            #endregion

        }

        private void AddHeader(string name, ListView listView, int width = 70)
        {
            ColumnHeader colhdr = new ColumnHeader() {
                Text = name,
                Width = width
            };
            listView.Columns.Add(colhdr);
        }

        // 刷新接收信息
        private void UpdateReceiveMsg()
        {
            listView_receive.Items.Clear();
            string sql = String.Format("SELECT FromName, SendTime, IsRead, ID FROM ViewMsg WHERE ToID = {0}", _fromID);
            DataTable dt = SQLHelper.GetDataTable(sql);
            int len = dt.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                string fromName = dt.Rows[i][0].ToString();
                string time = dt.Rows[i][1].ToString();
                string isRead = Convert.ToInt32(dt.Rows[i][2]) == 1 ? "已读" : "未读";
                string objID = dt.Rows[i][3].ToString();
                ListViewItem item = new ListViewItem(new string[] {
                    fromName, time, isRead, objID
                });
                listView_receive.Items.Add(item);
            }
        }
        // 刷新发送信息
        private void UpdateSendMsg()
        {
            listView_send.Items.Clear();
            string sql = String.Format("SELECT ToName, SendTime, IsRead, ID FROM ViewMsg WHERE FromID = {0}", _fromID);
            DataTable dt = SQLHelper.GetDataTable(sql);
            int len = dt.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                string toName = dt.Rows[i][0].ToString();
                string time = dt.Rows[i][1].ToString();
                string isRead = Convert.ToInt32(dt.Rows[i][2]) == 1 ? "已读" : "未读";
                string objID = dt.Rows[i][3].ToString();
                ListViewItem item = new ListViewItem(new string[] {
                    toName, time, isRead, objID
                });
                listView_send.Items.Add(item);
            }
        }

        // 发送信息
        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                int index = comboBox_toName.SelectedIndex;
                string msg = richTextBox1.Text;
                string time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                string sql = String.Format("INSERT INTO TBMsg VALUES({0}, {1}, '{2}', '{3}', {4})",
                                            _fromID, _toIDs[index], msg, time, 0);
                if (msg == "")
                {
                    if (MessageBox.Show("发送内容为空，是否仍然发送", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }

                if (SQLHelper.CommandSQL(sql) == 1)
                {
                    MessageBox.Show("信息发送成功");
                    UpdateSendMsg();
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

        // 标记为已读
        private void btn_SendRead_Click(object sender, EventArgs e)
        {
            if (listView_receive.SelectedIndices.Count == 0)
            {
                MessageBox.Show("未选择信息");
                return;
            }
            int index = listView_receive.SelectedIndices[0];
            string isRead = listView_receive.Items[index].SubItems[2].Text;
            if (isRead == "已读")
            {
                MessageBox.Show("信息已标记为已读");
                return;
            }
            string obgID = listView_receive.Items[index].SubItems[3].Text;
            string sql = String.Format("UPDATE TBMsg SET IsRead = 1 WHERE IsRead = {0}", obgID);
            if (SQLHelper.CommandSQL(sql) == 1)
            {
                MessageBox.Show("信息成功标志为已读");
                UpdateSendMsg();
            }
            else
            {
                MessageBox.Show("信息标志已读失败");
            }
            UpdateReceiveMsg();
        }

        private void listView_receivesend_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if ((sender as ListView).SelectedIndices.Count == 0)
                    return;
                int index = (sender as ListView).SelectedIndices[0];
                string obgID = (sender as ListView).Items[index].SubItems[3].Text;
                string sql = String.Format("SELECT Msg FROM TBMsg WHERE ID = {0}", obgID);
                DataTable dt = SQLHelper.GetDataTable(sql);
                richTextBox2.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
