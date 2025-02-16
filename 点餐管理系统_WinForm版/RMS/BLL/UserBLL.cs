using System.Data;
using DAL;

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
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            return _userDal.GetUserList();
        }
    }
}