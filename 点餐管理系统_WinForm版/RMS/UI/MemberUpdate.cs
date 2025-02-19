using System;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class MemberUpdate : Form
    {
        private readonly MemberTypeBLL _memberTypeBll = new MemberTypeBLL();
        private readonly MemberInfoBLL _memberInfoBLL = new MemberInfoBLL();
        public MemberUpdate()
        {
            InitializeComponent();
            LoadMemberTypeData();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MemberUpdate_Load(object sender, EventArgs e)
        {
            
        }
        //查询会员类型数据用于填充下拉框
        private void LoadMemberTypeData()
        {
            cmbMemType.DataSource = _memberTypeBll.GetMemberTypeList();
            cmbMemType.DisplayMember = "tname";
            cmbMemType.ValueMember = "tid";
        }
        
        // 加载待修改会员信息
        public void LoadMemberInfoShow(MemberInfo memberInfo)
        {
           txtMid.Text = memberInfo.Mid.ToString();
           txtMname.Text = memberInfo.Mname;
           cmbMemType.SelectedValue = memberInfo.Type ;
           txtMoney.Text = memberInfo.Money.ToString(CultureInfo.CurrentCulture);
           txtPoints.Text = memberInfo.Points.ToString();  
           txtPhoneNum.Text = memberInfo.PhoneNum;
           birDate.Text = memberInfo.Birthday.ToString(CultureInfo.InvariantCulture);
           registDate.Text = memberInfo.RegistDate.ToString(CultureInfo.InvariantCulture);
           endDate.Text = memberInfo.EndDate.ToString(CultureInfo.InvariantCulture);
           rdoMan.Checked = memberInfo.Gender == "男";
           rdoWomen.Checked = memberInfo.Gender == "女";
           txtDisount.Text = memberInfo.Discount.ToString(CultureInfo.InvariantCulture);
           
        }
        
        //修改会员信息事件
        private void btnOk_Click(object sender, EventArgs e)
        {
           
            //1. 获取数据来构造会员对象
            var memberInfo = new MemberInfo
            {
                Mid = Convert.ToInt32(txtMid.Text),
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
            var updateRes =  _memberInfoBLL.UpdateMemberInfo(memberInfo);
            if (updateRes > 0)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            if (updateRes == 0)
            {
                this.DialogResult = DialogResult.No;
                return;
            }
            DialogResult = DialogResult.Cancel;
        }
    }
}