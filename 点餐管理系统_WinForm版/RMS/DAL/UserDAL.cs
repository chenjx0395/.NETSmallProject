﻿using System;
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

        public DataTable GetUserList()
        {
            var sql =
                "select uid , username , password , realname , position from UserInfo";
            var dataTable = SqLiteHelper.ExecuteDataTable(sql);
            Console.WriteLine(dataTable.Rows.Count);
            return dataTable;
        }
    }
}