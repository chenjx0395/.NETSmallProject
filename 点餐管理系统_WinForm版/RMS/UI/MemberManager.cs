using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class MemberManager : Form
    {
        private MemberInfoBLL _memberInfoBLL = new MemberInfoBLL();
        private int _pageIndex = 1;
        private int _pageSize = 5;
        private int _total = 0;

        public MemberManager()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
            bindComboBox();
        }

        private void bindComboBox()
        {
            // 创建分页数据
            List<KeyValuePair<string, int>> pageItems = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("3页", 3),
                new KeyValuePair<string, int>("5页", 5),
                new KeyValuePair<string, int>("8页", 8),
                new KeyValuePair<string, int>("10页", 10),
            };

            // 设置 ComboBox 数据源
            comboBox1.DataSource = pageItems;
            comboBox1.DisplayMember = "Key"; // 显示“5 页”
            comboBox1.ValueMember = "Value"; // 获取实际值 5
            comboBox1.SelectedIndex = 1;
        }

        private void LoadData()
        {
            // 填充分页数据
            var queryMemberDTO = _memberInfoBLL.PagingQuery(_pageIndex, _pageSize);
            dgvMemmber.DataSource = queryMemberDTO.MemberInfos;
            _total = queryMemberDTO.PageCount;
            // 显示分页信息
            label2.Text = _pageIndex.ToString();
            label4.Text = _total.ToString();
        }

        private void MemberManager_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void MemberManager_Load(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            if (_pageIndex == 1)
            {
                MessageBox.Show("已经是第一页了");
                return;
            }

            _pageIndex -= 1;
            LoadData();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, System.EventArgs e)
        {
            if (_pageIndex == _total)
            {
                MessageBox.Show("已经是最后一页了");
                return;
            }

            _pageIndex += 1;
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _pageSize = ((KeyValuePair<string, int>)comboBox1.SelectedItem).Value;
            _pageIndex = 1;
            LoadData();
        }

        /// <summary>
        /// 打开添加会员界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void btnAddMemMber_Click(object sender, EventArgs e)
        {
            var memberAdd = new MemberAdd();
            var dialogResult = memberAdd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show("新增会员成功");
                _pageIndex = _total + 1;
                LoadData();
            }
            else
            {
                MessageBox.Show("新增会员失败");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //获取待删除会员的ID
            if (dgvMemmber.CurrentRow == null)
            {
                Console.WriteLine("请先选择要删除的会员");
                return;
            }

            var mid = Convert.ToInt32(dgvMemmber.CurrentRow.Cells[0].Value);
            foreach (DataGridViewCell VARIABLE in dgvMemmber.CurrentRow.Cells)
            {
                Console.WriteLine(VARIABLE.Value);
            }

            var deleteRes = _memberInfoBLL.DeleteMemberInfoById(mid);
            if (deleteRes == 1)
            {
                MessageBox.Show("删除会员成功");
                LoadData();
            }
            else
            {
                MessageBox.Show("删除会员失败");
            }
        }

        /// <summary>
        /// 检索会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void button5_Click(object sender, EventArgs e)
        {
            // 如果输入框的文本可以转换为整型,代表更加ID查询会员
            if (int.TryParse(textBox1.Text, out int mid))
            {
                dgvMemmber.DataSource = _memberInfoBLL.GetMemberInfoById(mid);
            }
            else
            {
                dgvMemmber.DataSource = _memberInfoBLL.LikeGetMemberInfoByName(textBox1.Text);
            }
                
        }
    }
}