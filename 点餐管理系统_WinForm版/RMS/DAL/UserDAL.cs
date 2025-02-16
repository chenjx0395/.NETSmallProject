using System;
using System.Data;
using System.Data.SQLite;
using Model;

namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>用户信息</returns>
        public UserInfo Login(string username, string password)
        {
            var sql =
                "select uid , username , password , realname , position from UserInfo where username = @username and password = @password;";
            SQLiteParameter[] parms =
            {
                new SQLiteParameter("@username", username),
                new SQLiteParameter("@password", password)
            };
            var dataReader = SqLiteHelper.ExecuteReader(sql, parms);
            UserInfo userInfo = null;
            if (dataReader.Read())
            {
                userInfo = new UserInfo
                {
                    Uid = dataReader.GetInt32(0),
                    Username = dataReader.GetString(1),
                    Password = dataReader.GetString(2),
                    RealName = dataReader.GetString(3),
                    Position = dataReader.GetString(4)
                };
            }
            dataReader.Close();
            return userInfo;

        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            var sql =
                "select uid , username , password , realname , position from UserInfo";
            var dataTable = SqLiteHelper.ExecuteDataTable(sql);
            Console.WriteLine(dataTable.Rows.Count);
            return dataTable;
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>1 代表添加成功</returns>
        public int InsertUser(UserInfo userInfo)
        {
            var sql =
                "insert into UserInfo(username,password,realname,position) values(@username,@password,@realname,@position);";
            SQLiteParameter[] parms =
            {
                new SQLiteParameter("@username", userInfo.Username),
                new SQLiteParameter("@password", userInfo.Password),
                new SQLiteParameter("@realname", userInfo.RealName),
                new SQLiteParameter("@position", userInfo.Position)
            };
            var result = SqLiteHelper.ExecuteNonQuery(sql, parms);
            return result;
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>1-修改成功</returns>
        public int UpdateUser(UserInfo userInfo)
        {
            var sql =
                "update UserInfo set username = @username , password = @password , realname = @realname , position = @position where uid = @uid;";
            SQLiteParameter[] parms =
            {
                new SQLiteParameter("@username", userInfo.Username),
                new SQLiteParameter("@password", userInfo.Password),
                new SQLiteParameter("@realname", userInfo.RealName),
                new SQLiteParameter("@position", userInfo.Position),
                new SQLiteParameter("@uid", userInfo.Uid)
            };
            var result = SqLiteHelper.ExecuteNonQuery(sql, parms);
            return result;
        }
        /// <summary>
        /// 根据员工ID删除员工
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>1-代表删除成功</returns>
        public int DeleteUserById(int userId)
        {
            var sql = "delete from UserInfo where uid = @uid;";
            SQLiteParameter[] parms =
            {
                new SQLiteParameter("@uid", userId)
            };
            var result = SqLiteHelper.ExecuteNonQuery(sql, parms);
            return result;
        }
    }
}