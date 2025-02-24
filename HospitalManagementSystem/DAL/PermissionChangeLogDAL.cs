using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class PermissionChangeLogDAL
    {
        //新增
        public int AddPermissionChangeLog(PermissionChangeLog permissionChangeLog)
        {
            const string sql = @"INSERT INTO 
                                  dbo.permissionChangeLog(FromUserId,TargetType,ActionType,Details,UpdateTime) 
                                  VALUES(@FromUserId,@TargetType,@ActionType,@Details,@UpdateTime)";
            //构造参数数组
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FromUserId",permissionChangeLog.FromUserId),
                new SqlParameter("@TargetType",permissionChangeLog.TargetType),
                new SqlParameter("@ActionType",permissionChangeLog.ActionType),
                new SqlParameter("@Details",permissionChangeLog.Details),
                new SqlParameter("@UpdateTime",permissionChangeLog.UpdateTime),
            };
            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }
    }
}