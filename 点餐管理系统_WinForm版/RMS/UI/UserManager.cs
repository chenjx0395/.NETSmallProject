using System;
using System.Data;
using System.Windows.Forms;
using BLL;

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
    }
}
