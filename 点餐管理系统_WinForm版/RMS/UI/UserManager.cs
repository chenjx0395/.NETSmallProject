using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class UserManager : Form
    {
        private readonly UserLogin _userLoginForm;
        private readonly UserBLL _userBLL = new UserBLL();
        public UserManager()
        {
            InitializeComponent();
        }
        public UserManager(UserLogin userLogin) : this()
        {
            _userLoginForm = userLogin;
            LoadData();
        }

        private void LoadData()
        {
            DataTable dataTable = _userBLL.GetUserList();
            dataGridView1.DataSource = dataTable;
        }

        private void UserManager_Load(object sender, EventArgs e)
        {

        }

        private void UserManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            _userLoginForm.Close();
        }
        /// <summary>
        /// 双击表格中的行，数据显示到对应文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.SelectedRows[0];
            userIdTextBox.Text = dataGridViewRow.Cells[0].Value.ToString();
            usernameTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
            passwordTextBox3.Text = dataGridViewRow.Cells[2].Value.ToString();
            realnameTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
            positionRadioButton1.Checked = dataGridViewRow.Cells[4].Value.ToString() == "员工" ? true : false;
            positionRadioButton2.Checked = dataGridViewRow.Cells[4].Value.ToString() == "经理" ? true : false;
        }
        /// <summary>
        /// 新增员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertUserButton_Click(object sender, EventArgs e)
        {
            // 构造用户对象
            var userInfo = new UserInfo
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox3.Text,
                RealName = realnameTextBox.Text,
                Position = positionRadioButton1.Checked ? "员工" : "经理"
            };
            // 调用UserBLL添加用户方法
            var insertRes = _userBLL.InsertUser(userInfo);
            if (insertRes == 1)
            {
                MessageBox.Show("添加成功");
                LoadData();
                // 清空文本框
                usernameTextBox.Text = "";
                passwordTextBox3.Text = "";
                realnameTextBox.Text = "";
                positionRadioButton1.Checked = true;
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
