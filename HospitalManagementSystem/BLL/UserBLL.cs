using System.Collections.Generic;
using System.Data;
using Common;
using Common.Utils;
using DAL;
using Model;
using Model.DTO;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL = new UserDAL();
        private readonly PermissionDAL _permissionDAL = new PermissionDAL();

        public Result<User> GetUser(string account, string password)
        {
            //对密码进行MD5加密
            password = MD5Util.GetMD5(password);
            var user = _userDAL.GetUser(account, password);
            var result = new Result<User>
            {
                Message = user == null ? "账号密码错误" : "操作成功",
                Code = user == null ? 4001 : 2000,
                Value = user
            };
            //登录成功获取用户权限信息，并设置到全局上下文中
            if (result.Code == 2000) SaveToGlobalContext(result.Value);
            return result;
        }

        private void SaveToGlobalContext(User user)
        {
            //查询当前用户的所有权限id值
            var permissionsDT = _permissionDAL.GetUserPermissions(user.UserId);
            var userPermissions = new List<int>();
            foreach (DataRow row in permissionsDT.Rows)
            {
                userPermissions.Add(int.Parse(row[0].ToString()));
            }

            GlobalContext.CurrentUser = new UserPermissionsDTO
            {
                UserPermissions = userPermissions,
                Name = user.Name,
                UserId = user.UserId
                
            };
        }
        
        public Result<DataTable> GetUserRolesList()
        {
            var userRolesList = _userDAL.GetUserRolesList();
            if (userRolesList != null)
            {
                return new Result<DataTable>
                {
                    Code = 2000,
                    Message = "操作成功",
                    Value = userRolesList
                };
            }
            else
            {
                return new Result<DataTable>
                {
                    Code = 5000,
                    Message = "操作失败"
                };
            }

        }

    }
}