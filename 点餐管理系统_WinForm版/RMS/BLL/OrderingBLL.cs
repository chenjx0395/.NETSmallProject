using Common;
using DAL;

namespace BLL
{
    public class OrderingBLL
    {

        //点餐界面登录
        public int Login(string username, string password)
        {
            var userDAL = new UserDAL();
            password = MD5Util.GetMD5(password);
            var userInfo = userDAL.Login(username, password);
            return userInfo == null ? 0 : 1;

        }
    }
}