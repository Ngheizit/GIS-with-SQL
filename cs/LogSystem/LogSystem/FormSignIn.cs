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
    public partial class FormSignIn : Form
    {
        private string m_id;
        public string Id { get { return this.m_id; } }
        private string m_username;
        public string Username { get { return this.m_username; } }

        public FormSignIn()
        {
            InitializeComponent();

            #region → Load 窗体事件
            {
                this.Load += (s, e) => {
                    Pages.SelectedPage = Page_SignIn; // 初始打开界面为登录界面
                };
            }
            #endregion
            Page_SignIn.MouseDown +=Pages_MouseDown;
            Page_SignIn.MouseMove += Pages_MouseMove;
            Page_SignOut.MouseDown += Pages_MouseDown;
            Page_SignOut.MouseMove += Pages_MouseMove;
            
        }

        #region → 窗体移动 事件集
        private int f_x, f_y; // 鼠标点击坐标位置
        private void Pages_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - f_x), this.Location.Y + (e.Y - f_y));
            }
        }
        private void Pages_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                f_x = e.X;
                f_y = e.Y;
            }
        } 
        #endregion


        #region → 登录用户 事件
        private void btn_SignIn_Ok_Click(object sender, EventArgs e)
        {
            // 1. 获取 用户名 和 密码
            string strUsername = tbx_SignIn_Username.Text,
                   strPassword = tbx_SignIn_Password.Text;

            using (DataTable dt = SqlUtils.GetDataTable("SELECT * FROM TBUser WHERE UserName = '{0}';", strUsername)) {
                // 2. 判断 用户名存不存在 和 登录密码是否正确
                if (dt.Rows.Count == 0 || dt.Rows[0][2].ToString() != strPassword) {
                    MessageBox.Show(String.Format("用户名或密码错误", strUsername), "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. 跳转窗体完成登录
                this.m_id = dt.Rows[0][0].ToString();
                this.m_username = dt.Rows[0][1].ToString();
                this.DialogResult = DialogResult.OK;
            }
        } 
        #endregion

        #region → 注册用户 事件
        private void btn_SignOut_Ok_Click(object sender, EventArgs e)
        {
            // 1. 获取 用户名 和 密码
            string strUsername = tbx_SignOut_Username.Text,
                   strPassword = tbx_SignOut_Password.Text,
                   strRePassword = tbx_SignOut_RePassword.Text;

            // 2. 判断 用户名 是否存在
            using(DataTable dt = SqlUtils.GetDataTable("SELECT COUNT(*) FROM TBUser WHERE UserName = '{0}';", strUsername)) {
                if (dt.Rows[0][0].ToString() != "0") {
                    MessageBox.Show(String.Format("用户名【{0}】已存在，无法注册", strUsername), "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 3. 判断 两次密码 是否填写正确
            if (strPassword != strRePassword) {
                MessageBox.Show("两次输入密码不相同，无法注册", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. 执行 注册
            if (SqlUtils.CommandSQL("INSERT INTO TBUser(UserName, UserPassword) VALUES('{0}', '{1}');", strUsername, strPassword) == 1) {
                MessageBox.Show(String.Format("用户【{0}】注册成功", strUsername));
            }
            else {
                MessageBox.Show(String.Format("用户【{0}】注册失败，问题未知", strUsername), "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 
        #endregion

        #region → 退出程序 事件
        private void Pages_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page == btn_Exit)
            {
                Application.Exit();
            }
        } 
        #endregion



 
    }
}
