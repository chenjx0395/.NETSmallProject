using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class UserDAL
    {
        //根据账号密码获取登录信息
        public User GetUser(string account, string password)
        {
            const string sql = @"select userid, account, password, sex, address, phone, spell, createtime, updatetime, isremove, name
                                from Users where Account=@Account and Password=@Password and IsRemove = 0";
            var parameters = new[]
            {
                new SqlParameter("@Account",account),
                new SqlParameter("@Password",password)
            };
            var reader = SQLHelper.ExecuteReader(sql, parameters);
            var user = reader.Read() ? new User
            {
              UserId = reader.GetInt32(0),
              Account = reader.GetString(1),
              Password = reader.GetString(2),
              Sex = reader.GetString(3),
              Address = reader.GetString(4),
              Phone = reader.GetString(5),
              Spell = reader.GetString(6),
              CreateTime = reader.GetDateTime(7),
              UpdateTime = reader.GetDateTime(8),
              IsRemove = reader.GetBoolean(9),
              Name = reader.GetString(10)
            } : null;
            return user;
        }
        
        //查询用户的角色信息列表
        public DataTable GetUserRolesList()
        {
            const string sql = @"select u.account as 用户账户, u.name as 用户姓名 , r.Name as 角色名                                from role r
                                          join userrole ur on r.roleid = ur.roleid
                                          join users u on u.userid = ur.userid
                                where  u.isremove = 0";
            return SQLHelper.FillDataTable(sql);
        }
    }
}