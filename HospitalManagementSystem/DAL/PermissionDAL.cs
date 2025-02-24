using System;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class PermissionDAL
    {
        //新增权限并获取新增的ID
        public int AddPermission(SQLHelper.TransactionContext tran, Permission permission)
        {
            const string sql = @"insert into Permission(Name,Description,IsRemove) values(@Name,@Description,@IsRemove);
            SELECT SCOPE_IDENTITY() ";
            return Convert.ToInt32(SQLHelper.ExecuteScalar(tran,sql, 
                new SqlParameter("@Name", permission.Name), 
                new SqlParameter("@Description", permission.Description)
                , new SqlParameter("@IsRemove", permission.IsRemove)));
        }
        
        //新增模块权限关系表数据
        public int AddModulePermission(SQLHelper.TransactionContext tran, ModulePermission modulePermission)
        {
            const string sql = @"insert into modulePower(ModuleId,PermissionId,IsRemove) values(@ModuleId,@PermissionId,@IsRemove)";
            return SQLHelper.ExecuteNonQuery(tran,sql, 
                new SqlParameter("@ModuleId", modulePermission.ModuleId), 
                new SqlParameter("@PermissionId", modulePermission.PermissionId),
                new SqlParameter("@IsRemove", modulePermission.IsRemove));
        }
        
        //查询权限列表
        public DataTable GetPermissionList()
        {
            const string sql = @"select permissionid, name, description, isremove from Permission where IsRemove=0";
            return SQLHelper.FillDataTable(sql);
        }
        
        //根据用户ID查询用户权限
        public DataTable GetUserPermissions(int userId)
        {
            const string sql = @"select PermissionId 
                                    from userRole ur 
                                        join rolePower rp on ur.RoleId = rp.RoleId
                                    where UserId = @userId;";
            return SQLHelper.FillDataTable(sql, new SqlParameter("@userId", userId));
        }
        
        //修改权限
        public int UpdatePermission(SQLHelper.TransactionContext tran, Permission permission)
        {
            const string sql = @"update Permission set Name=@Name,Description=@Description,IsRemove=@IsRemove where PermissionId=@PermissionId";
            return SQLHelper.ExecuteNonQuery(tran,sql, 
                new SqlParameter("@Name", permission.Name), 
                new SqlParameter("@Description", permission.Description),
                new SqlParameter("@IsRemove", permission.IsRemove),
                new SqlParameter("@PermissionId", permission.PermissionId));
        }
    }
}