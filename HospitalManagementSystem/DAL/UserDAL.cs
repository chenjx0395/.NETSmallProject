using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class UserDAL
    {
        //根据账号密码获取登录信息
        public User GetUser(string account, string password)
        {
            const string sql = "select count(UserId) from User where Account=@Account and Password=@Password";
            var parameters = new[]
            {
                new SqlParameter("@Account",account),
                new SqlParameter("@Password",password)
            };
            var reader = SQLHelper.ExecuteReader(sql, parameters);
            var user = reader.Read() ? new User
            {
                Account = account,
                UserId = int.Parse(reader[0].ToString()),
            } : null;
            return user;
        }
    }
}