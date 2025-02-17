using System;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class UserManager : Form
    {
        private readonly UserBLL _userBLL = new UserBLL();
        public UserManager()
        {
            InitializeComponent();
            LoadData();
        }
        

        private void LoadData()
        {
            var dataTable = _userBLL.GetUserList();
            dataGridView1.DataSource = dataTable;
        }

        private void UserManager_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭所有打开窗口并退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 双击表格中的行，数据显示到对应文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewRow = dataGridView1.SelectedRows[0];
            userIdTextBox.Text = dataGridViewRow.Cells[0].Value.ToString();
            usernameTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
            passwordTextBox3.Text = dataGridViewRow.Cells[2].Value.ToString();
            realnameTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
            positionRadioButton1.Checked = dataGridViewRow.Cells[4].Value.ToString() == "员工" ;
            positionRadioButton2.Checked = dataGridViewRow.Cells[4].Value.ToString() == "经理";
        }
        /// <summary>
        /// 新增员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertUserButton_Click(object sender, EventArgs e)
        {
            // 构造用户对象
            var userInfo = BuildingUserInfo();
            // 调用UserBLL添加用户方法
            var insertRes = _userBLL.InsertUser(userInfo);
            UpdateResultFeedback(insertRes,"新增");
        }

        /// <summary>
        /// 修改数据后对修改结构的界面反馈
        /// </summary>
        /// <param name="updateRes">修改结果</param>
        /// <param name="msg">提示信息</param>
        private void UpdateResultFeedback(int updateRes, string msg)
        {
            if (updateRes == 1)
            {
                MessageBox.Show($@"{msg}成功");
                LoadData();
                // 清空文本框
                userIdTextBox.Text = "";
                usernameTextBox.Text = "";
                passwordTextBox3.Text = "";
                realnameTextBox.Text = "";
                positionRadioButton1.Checked = true;
            }
            else
            {
                MessageBox.Show($@"{msg}失败");
            }
        }

        /// <summary>
        /// 根据文本框构造用户对象
        /// </summary>
        /// <returns></returns>
        private UserInfo BuildingUserInfo()
        {
            var userInfo = new UserInfo
            {
                Uid = Convert.ToInt32(userIdTextBox.Text),
                Username = usernameTextBox.Text,
                Password = passwordTextBox3.Text,
                RealName = realnameTextBox.Text,
                Position = positionRadioButton1.Checked ? "员工" : "经理"
            };
            return userInfo;
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateUserButton_Click(object sender, EventArgs e)
        {
            var id = GetUserId();
            if (id == -1) return;
            // 构造用户对象
            var userInfo = BuildingUserInfo();
            // 调用UserBLL修改用户方法
            var updateRes = _userBLL.UpdateUser(userInfo);
            // 调用结果反馈方法
            UpdateResultFeedback(updateRes,"修改");
        }



        /// <summary>
        /// 删除选中的员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            var id = GetUserId();
            if (id == -1) return;
            // 调用UserBLL根据ID删除用户方法
            var deleteRes = _userBLL.DeleteUserById(id);
            UpdateResultFeedback(deleteRes,"删除");
        }

        /// <summary>
        /// 获取员工ID，如果获取不到，则弹窗提示
        /// </summary>
        /// <returns>-1 代表没选员工</returns>
        private int GetUserId()
        {
            if (string.IsNullOrWhiteSpace(userIdTextBox.Text))
            {
                MessageBox.Show(@"请先选择要操作员工");
                return -1;
            }
            var id = 0;
            try
            {
                 id = Convert.ToInt32(userIdTextBox.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"系统异常");
                Console.WriteLine(e.Message);
            }
            return id;
        }
    }
}
