using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSystem
{
    public partial class FormMain : Form
    {
        private string m_id;
        private string m_username;
        private List<int> m_idList = new List<int>();

        public FormMain(string id, string username)
        {
            InitializeComponent();
            this.m_id = id;
            this.m_username = username;
            this.Text = String.Format("欢迎，{0} o(*￣▽￣*)o", m_username);

            UpdateUsers();
            UpdateOutbox();
            UpdateInbox();
            UpdateUndoMsg();

            new Timer()
            {
                Enabled = true,
                Interval = 10000 // 十秒
            }.Tick += (s, e) => {
                UpdateOutbox();
                UpdateInbox();
                UpdateUndoMsg();
            };
        }
        #region → 获取 可以发送至的用户
        private void UpdateUsers()
        {
            string sql = String.Format("SELECT ID, UserName FROM TBUser WHERE ID != '{0}'", m_id);
            DataTable dt = SqlUtils.GetDataTable(sql);
            int len = dt.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                m_idList.Add(Convert.ToInt32(dt.Rows[i][0]));
                comboBox_SendToUsername.Items.Add(dt.Rows[i][1]);
            } 
        }
        #endregion

        #region → 更新收件箱
        private void UpdateInbox()
        {
            using (DataTable dt = SqlUtils.GetDataTable("SELECT FromName 来自, SendTime 接收时间, IsRead 已读状态, ID 邮件标识符 FROM ViewMsg WHERE ToID = {0}", m_id))
            {
                dataGridView_Inbox.DataSource = dt;
            }
        }
        #endregion

        #region → 更新发件箱
        private void UpdateOutbox()
        {
            using (DataTable dt = SqlUtils.GetDataTable("SELECT ToName 发送至, SendTime 发送时间, IsRead 对方是否已读, ID 邮件标识符 FROM ViewMsg WHERE FromID = {0}", m_id))
            {
                dataGridView_Outbox.DataSource = dt;
            }
        }
        #endregion

        #region → 发送邮件 事件
        private void btn_SendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                int index = comboBox_SendToUsername.SelectedIndex;
                string msg = tbx_SendText.Text;
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = String.Format("INSERT INTO TBMsg(FromID, ToID, Msg, SendTime, IsRead) VALUES({0}, {1}, '{2}', '{3}', {4})",
                                            m_id, m_idList[index], msg, time, 0);
                if (msg == "")
                {
                    if (MessageBox.Show("发送内容为空，是否仍然发送", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }

                if (SqlUtils.CommandSQL(sql) == 1)
                {
                    MessageBox.Show("信息发送成功");
                    UpdateOutbox();
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
        #endregion

        #region → 显示接收和发送的信息
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string obgID = (sender as DataGridView).SelectedRows[0].Cells[3].Value.ToString();
            DataTable dt = SqlUtils.GetDataTable("SELECT Msg FROM TBMsg WHERE ID = {0}", obgID);
            tbx_Description.Text = dt.Rows[0][0].ToString();
        }
        #endregion

        #region → 标记为已读事件
        private void btn_SetRead_Click(object sender, EventArgs e)
        {
            if (dataGridView_Inbox.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择信息");
                return;
            }
            string isRead = dataGridView_Inbox.SelectedRows[0].Cells[2].Value.ToString();

            if (isRead == "True")
            {
                MessageBox.Show("信息已标记为已读");
                return;
            }
            string obgID = dataGridView_Inbox.SelectedRows[0].Cells[3].Value.ToString();
            string sql = String.Format("UPDATE TBMsg SET IsRead = 1 WHERE ID = {0}", obgID);
            if (SqlUtils.CommandSQL(sql) == 1)
            {
                MessageBox.Show("信息成功标志为已读");
                UpdateInbox();
            }
            else
            {
                MessageBox.Show("信息标志已读失败");
            }
        } 
        #endregion

        #region → 显示未处理信息条目
        private void UpdateUndoMsg()
        {
            string sql = String.Format("SELECT ID FROM ViewMsg WHERE ToID = {0} AND IsRead = 0", m_id);
            DataTable dt = SqlUtils.GetDataTable(sql);
            int count = dt.Rows.Count;
            page_Inbox.Caption = String.Format("收件箱(未处理信息：{0})", count);
        }
        #endregion

        #region → 切换账户 和 退出 事件
        private void pages_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page == btn_ReSignIn)
            {
                Application.Restart();
            }
            else if (e.Page == btn_Exit)
            {
                Application.Exit();
            }
        }
        #endregion

    }
}
