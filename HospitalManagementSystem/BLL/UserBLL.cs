using Common;
using Common.Utils;
using DAL;
using Model;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL = new UserDAL();
        
        public Result<User> GetUser(string account, string password)
        {
            //对密码进行MD5加密
            password = MD5Util.GetMD5(password);
            var result = new Result<User>
            {
                Message = _userDAL.GetUser(account, password) == null ? "账号密码错误" : "操作成功",
                Code = _userDAL.GetUser(account, password) == null ? 4001 : 2000
            };
            //登录成功获取用户权限信息，并设置到全局上下文中
            return null;
        }

    }
}