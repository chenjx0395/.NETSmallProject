using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class MemberAdd : Form
    {
        private readonly MemberTypeBLL _memberTypeBll = new MemberTypeBLL();
        private readonly MemberInfoBLL _memberInfoBll = new MemberInfoBLL();
        
        public MemberAdd()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadMemberTypeData();
        }

        /// <summary>
        /// 查询会员类型数据用于填充下拉框
        /// </summary>
        private void LoadMemberTypeData()
        {
            cmbMemType.DataSource = _memberTypeBll.GetMemberTypeList();
            cmbMemType.DisplayMember = "tname";
            cmbMemType.ValueMember = "tid";
        }

        /// <summary>
        /// 调用新增会员方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //1. 获取数据来构造会员对象
            var memberInfo = new MemberInfo
            {
                Mname = txtMname.Text,
                Gender = rdoMan.Checked ? "男" : "女",
                Type = Convert.ToInt32(cmbMemType.SelectedValue),
                PhoneNum = txtPhoneNum.Text,
                Discount = Convert.ToDouble(txtDisount.Text),
                Money = Convert.ToDouble(txtMoney.Text),
                Points = Convert.ToInt32(txtPoints.Text),
                Birthday = Convert.ToDateTime(birDate.Text),
                RegistDate = Convert.ToDateTime(registDate.Text),
                EndDate = Convert.ToDateTime(endDate.Text),
                RemoveFlag = 0
            };
            var insertRes = _memberInfoBll.InsertMemberInfo(memberInfo);
            if (insertRes > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
    
    
}
