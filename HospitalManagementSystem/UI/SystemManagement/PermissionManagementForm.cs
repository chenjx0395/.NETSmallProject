using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Model;

namespace HospitalManagementSystem.SystemManagement
{
    public partial class PermissionManagementForm : Form
    {
        private  readonly ModuleBLL _moduleBLL = new ModuleBLL();
        private  readonly RoleBLL _roleBLL = RoleBLL.GetRoleBLLProxy();
        private  readonly UserBLL _userBLL = new UserBLL();

        public PermissionManagementForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region 界面数据加载

        //加载角色列表
        private void LoadRoleList()
        {
            var result = _roleBLL.GetRoleList();
            if (result.Code != 2000)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                dataGridView1.DataSource = result.Value;
            }
        }

        //加载员工以及角色信息
        private void LoadUserRoleList()
        {
            var userRolesList = _userBLL.GetUserRolesList();
            if (userRolesList.Code != 2000)
            {
                MessageBox.Show(userRolesList.Message);
            }
            else
            {
                dataGridView2.DataSource = userRolesList.Value;
            }
        }

        //加载角色下列框
        private void LoadRuleCombBox()
        {
            //获取下列框信息
            var roleList = _roleBLL.GetRoleList();
            if (roleList.Code != 2000)
            {
                MessageBox.Show(roleList.Message);
            }
            else
            {
                comboBox1.DataSource = roleList.Value;
                comboBox1.DisplayMember = "角色名";
                comboBox1.ValueMember = "编号";
            }
        }
        
        //加载模块及其下权限信息,并根据信息构造复选框
        private void LoadModulePermissionList()
        {
            panel1.AutoScroll = true;
            //创建外容器
            var box = new GroupBox
            {
                Size = new Size(550, 1000),
                Text = @"权限信息",
            };
            panel1.Controls.Add(box);

            var modulePermissionList = _moduleBLL.GetModulePermissionList();
            if (modulePermissionList.Code != 2000)
            {
                MessageBox.Show(modulePermissionList.Message);
                return;
            }

            //模组默认宽度高度为:W130,H150. 
            //如果权限数量大于4个,则宽度翻倍,多多少个翻多少倍,如果翻倍;;;TODO,简化设计
            var openWidth = 130;
            var openHeight = 150;
            var heightUnit = 0;
            var widthUnitSum = 4;
            // X轴偏移量
            var xPos = 0;
            //构造复选框组
            for (int i = 0; i < modulePermissionList.Value.Count; i++)
            {
                //用于判断当前的复选框组是否需要换行展示

                var module = modulePermissionList.Value[i];

                // 修改后的模块容器创建逻辑
                var widthUnit = module.Permissions.Count / 5 + 1;
                widthUnitSum -= widthUnit;
                if (widthUnitSum < 0)
                {
                    heightUnit++;
                    widthUnitSum = 4 - widthUnit;
                    xPos = 0;
                }

                var groupBox = new GroupBox
                {
                    Text = module.Name,
                    Width = openWidth * widthUnit,
                    Height = openHeight,
                    Location = new Point(openWidth * xPos + 15, 20 + (heightUnit * openHeight) + (heightUnit * 10)),
                    Tag = module.ModuleId,
                };
                xPos++;
                // 添加全选复选框
                var chkModule = new CheckBox
                {
                    Text = @"全选",
                    Location = new Point(10, 15),
                    // Margin = new Padding(0, 50, 0, 10) // 添加下边距
                };
                chkModule.CheckedChanged += ModuleCheckBox_CheckedChanged;
                groupBox.Controls.Add(chkModule);

                // 添加权限复选框
                int yPos = 45;
                int internalWidth = 20;
                for (int j = 0, n = 1, xxPos = 0; j < module.Permissions.Count; j++, n++)
                {
                    // 换行，即X偏移量翻倍
                    if (n == 5)
                    {
                        xxPos++;
                        n = 1;
                        yPos = 45;
                    }

                    var permission = module.Permissions[j];
                    var chkPermission = new CheckBox
                    {
                        Text = permission.Name,
                        Location = new Point(internalWidth + (120 * xxPos), yPos),
                        AutoSize = true,
                        Tag = permission.PermissionId,
                    };
                    chkPermission.CheckedChanged += PermissionCheckBox_CheckedChanged;
                    groupBox.Controls.Add(chkPermission);


                    yPos += 25;
                }

                box.Controls.Add(groupBox);
            }
        }

        // 3. 事件处理方法
        private void ModuleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var chkModule = sender as CheckBox;
            var groupBox = chkModule?.Parent as GroupBox;

            // 获取所有权限复选框（排除全选框）
            var permissionChecks = groupBox?.Controls
                .OfType<CheckBox>()
                .Where(c => c != chkModule)
                .ToList();

            // 临时取消事件订阅
            if (permissionChecks != null)
            {
                foreach (var chk in permissionChecks)
                {
                    chk.CheckedChanged -= PermissionCheckBox_CheckedChanged;
                }

                // 批量设置状态
                foreach (var chk in permissionChecks)
                {
                    chk.Checked = chkModule.Checked;
                }

                // 重新订阅事件
                foreach (var chk in permissionChecks)
                {
                    chk.CheckedChanged += PermissionCheckBox_CheckedChanged;
                }
            }
        }


        private void PermissionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var changedCheckBox = sender as CheckBox;
            var groupBox = changedCheckBox?.Parent as GroupBox;

            // 查找模块级复选框
            var moduleCheckBox = groupBox?.Controls.OfType<CheckBox>()
                .FirstOrDefault(c => c.Text == @"全选");

            if (moduleCheckBox != null)
            {
                // 检查是否所有权限都被选中
                bool allChecked = groupBox.Controls.OfType<CheckBox>()
                    .Where(c => c != moduleCheckBox)
                    .All(c => c.Checked);

                moduleCheckBox.CheckedChanged -= ModuleCheckBox_CheckedChanged; // 避免递归
                moduleCheckBox.Checked = allChecked;
                moduleCheckBox.CheckedChanged += ModuleCheckBox_CheckedChanged;
            }
        }

        #endregion

        #region 打开新窗口事件

        //打开新增权限窗口事件
        private void button2_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"此操作非常危险！请确定你需要新增权限！执行操作后必须迭代版本，不然会使程序异常！"
                , @"警告", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                new PermissionAddOrUpdate().ShowDialog();
            }
        }

        //打开新增模块窗口事件
        private void button7_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"此操作非常危险！请确定你需要新增权限！执行操作后必须迭代版本，不然会使程序异常！"
                , @"警告", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                new ModuleAddOrUpdate().ShowDialog();
            }
        }

        #endregion


        private void PermissionManagementForm_Load(object sender, EventArgs e)
        {
            LoadRoleList();
            LoadUserRoleList();
            LoadModulePermissionList();
            LoadRuleCombBox();
        }

        //双击显示角色数据
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前行数据
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //将当前角色的权限与权限复选框相关联
            var rolePermissions = _roleBLL.GetRolePermissions(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
            ResetCheckboxStatus();
            //将对应ID值的复选框勾选
            SelectSpecifyCheckBox(rolePermissions.Value);

        }

        private void SelectSpecifyCheckBox(List<int> permissionIds)
        {
            foreach (var permissionId in permissionIds)
            {
                foreach (var chk in panel1.Controls[0].Controls.OfType<GroupBox>())
                {
                    foreach (var cb in chk.Controls.OfType<CheckBox>())
                    {
                        if (cb.Tag != null && Convert.ToInt32(cb.Tag) == permissionId)
                        {
                            cb.Checked = true;
                        }
                    }
                }
            }
            //检查模块内的复选框是否全部选中，如果全部选中，则将全选复选框也选中
            foreach (var chk in panel1.Controls[0].Controls.OfType<GroupBox>())
            {
                var moduleCheckBox = chk.Controls.OfType<CheckBox>().FirstOrDefault(c => c.Text == @"全选");
                if (moduleCheckBox != null)
                {
                    var allChecked = chk.Controls.OfType<CheckBox>()
                        .Where(c => c != moduleCheckBox)
                        .All(c => c.Checked);

                }
            }
        }
        
        //重置所有的复选框状态
        private void ResetCheckboxStatus()
        {
            foreach (var chk in panel1.Controls[0].Controls.OfType<GroupBox>())
            {
                foreach (var cb in chk.Controls.OfType<CheckBox>())
                {
                    cb.Checked = false;
                }
            }
        }

        //新增角色事件
        private void button12_Click(object sender, EventArgs e)
        {
            //获取所有选择的权限复选框的tag值
            var permissionIds = new List<int>();
            foreach (var chk in panel1.Controls[0].Controls.OfType<GroupBox>())
            {
                foreach (var cb in chk.Controls.OfType<CheckBox>())
                {
                    if (cb.Checked && cb.Tag != null)
                    {
                        permissionIds.Add((int)cb.Tag);
                    }
                }
            }
            //构建信息新增角色依旧角色权限关系表
            var role = new Role
            {
                Name = textBox1.Text,
                Description = textBox4.Text
            };
            var res = _roleBLL.AddRole(role, permissionIds);
            if (res.Code != 2000)
            {
                MessageBox.Show(res.Message);
                return;
            }

            ResetCheckboxStatus();
            textBox1.Text = "";
            textBox4.Text = "";
            LoadRoleList();
            LoadRuleCombBox();
        }
    }
}