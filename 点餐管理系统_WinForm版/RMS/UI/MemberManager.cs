using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class MemberManager : Form
    {
        private readonly MemberInfoBLL _memberInfoBLL = new MemberInfoBLL();
        private int _pageIndex = 1;
        private int _pageSize = 5;
        private int _total ;
        
        /// <summary>
        /// 会员更新传递当前选中的会员数据给更新窗口
        /// </summary>
        public event Action<MemberInfo> MemberUpdateEvent;  

        public MemberManager()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
            BindComboBox();
        }

        private void BindComboBox()
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
            var queryMemberDto = _memberInfoBLL.PagingQuery(_pageIndex, _pageSize);
            dgvMemmber.DataSource = queryMemberDto.MemberInfos;
            _total = queryMemberDto.PageCount;
            // 显示分页信息
            label2.Text = _pageIndex.ToString();
            label4.Text = _total.ToString();
        }

        private void MemberManager_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void MemberManager_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (_pageIndex == 1)
            {
                MessageBox.Show(@"已经是第一页了");
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (_pageIndex == _total)
            {
                MessageBox.Show(@"已经是最后一页了");
                return;
            }

            _pageIndex += 1;
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                MessageBox.Show(@"新增会员成功");
                _pageIndex = _total + 1;
                LoadData();
            }
            else
            {
                MessageBox.Show(@"新增会员失败");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //获取待删除会员的ID
            if (dgvMemmber.CurrentRow == null)
            {
                Console.WriteLine(@"请先选择要删除的会员");
                return;
            }

            var id = Convert.ToInt32(dgvMemmber.CurrentRow.Cells[0].Value);
            foreach (DataGridViewCell variable in dgvMemmber.CurrentRow.Cells)
            {
                Console.WriteLine(variable.Value);
            }

            var deleteRes = _memberInfoBLL.DeleteMemberInfoById(id);
            if (deleteRes == 1)
            {
                MessageBox.Show(@"删除会员成功");
                LoadData();
            }
            else
            {
                MessageBox.Show(@"删除会员失败");
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
            dgvMemmber.DataSource = int.TryParse(textBox1.Text, out var id) 
                ? _memberInfoBLL.GetMemberInfoById(id) 
                : _memberInfoBLL.LikeGetMemberInfoByName(textBox1.Text);
        }

        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            //绑定事件
            var memberUpdate = new MemberUpdate();
            MemberUpdateEvent += memberUpdate.LoadMemberInfoShow;
            // 构建用户对象
            if (dgvMemmber.CurrentRow == null)
            {
                Console.WriteLine(@"请先选择要修改的会员");
                return;
            }
            var rowData = dgvMemmber.CurrentRow.Cells;
            var memberInfo = new MemberInfo
            {
                Mid = Convert.ToInt32(rowData[0].Value),
                Mname = rowData[1].Value.ToString(),
                Gender = rowData[2].Value.ToString(),
                Type = Convert.ToInt32(rowData[3].Value),
                Discount = Convert.ToDouble(rowData[4].Value),
                Money = Convert.ToDouble(rowData[5].Value),
                Points = Convert.ToInt32(rowData[6].Value),
                Birthday = Convert.ToDateTime(rowData[7].Value),
                PhoneNum = rowData[8].Value.ToString(),
                RegistDate = Convert.ToDateTime(rowData[9].Value),
                EndDate = Convert.ToDateTime(rowData[10].Value),
            };
            MemberUpdateEvent?.Invoke(memberInfo);
            var dialogResult = memberUpdate.ShowDialog();
            //TODO 存在逻辑错误,先保证测试成功
            if (dialogResult == DialogResult.OK )
            {
                MessageBox.Show(@"修改会员信息成功");
                LoadData();
            }
            else
            {
                MessageBox.Show(@"修改会员信息失败");
            }
        }
    }
}