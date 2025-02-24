using System;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class RoleDAL
    {
        //获取角色列表
        public DataTable GetRoleList()
        {
            string sql = "select roleid as '编号', name as '角色名', description '描述' from Role where IsRemove = 0";
            return SQLHelper.FillDataTable(sql);
        }
        
        //新增角色，返回新增的ID
        public int AddRole(SQLHelper.TransactionContext tran, Role role)
        {
            string sql = "insert into Role(name, description) values(@name, @description); select @@IDENTITY";
            object id = SQLHelper.ExecuteScalar(tran,sql, new SqlParameter("@name", role.Name), new SqlParameter("@description", role.Description));
            return Convert.ToInt32(id);
        }
        
        //新增角色权限关系
        public int AddRolePermission(SQLHelper.TransactionContext tran, RolePermission rolePermission)
        {
            string sql = "insert into rolePower(roleid, permissionid) values(@roleid, @permissionid)";
            return SQLHelper.ExecuteNonQuery(tran, sql, new SqlParameter("@roleid", rolePermission.RoleId), new SqlParameter("@permissionid", rolePermission.PermissionId));
        }
        
        //根据角色ID查询权限
        public DataTable GetRolePermissions(int roleId)
        {
            string sql = "select PermissionId from rolePower where RoleId = @roleId;";
            return SQLHelper.FillDataTable(sql, new SqlParameter("@roleid", roleId));
        }
    }
}