using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDal = new UserDAL();


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>0-账号密码错误 1-员工登录 2-经理登录</returns>
        public int Login(string username, string password)
        {
            var userInfo = _userDal.Login(username, password);
            if (userInfo == null)
            {
                return 0;
            }
            switch (userInfo.Position)
            {
                case "员工":
                    return 1;
                case "经理":
                    return 2;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            return _userDal.GetUserList();
        }
        /// <summary>
        /// 新增员工
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>1 代表新增成功</returns>
        public int InsertUser(UserInfo userInfo)
        {
            return _userDal.InsertUser(userInfo);
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>1-修改成功</returns>
        public int UpdateUser(UserInfo userInfo)
        {
            return _userDal.UpdateUser(userInfo);
        }
        /// <summary>
        /// 更加员工ID删除员工
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>1-代表删除成功</returns>
        public int DeleteUserById(int userId)
        {
            return _userDal.DeleteUserById(userId);
        }
    }
}