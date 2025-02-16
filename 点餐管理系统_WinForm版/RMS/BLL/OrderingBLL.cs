using Common;
using DAL;

namespace BLL
{
    public class OrderingBLL
    {
        /// <summary>
        /// 点餐界面登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>0-账号密码错误</returns>
        public int Login(string username, string password)
        {
            var userDAL = new UserDAL();
            password = MD5Util.GetMD5(password);
            var userInfo = userDAL.Login(username, password);
            return userInfo == null ? 0 : 1;

        }
    }
}