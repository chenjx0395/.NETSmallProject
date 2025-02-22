using Common;
using DAL;
using Model;

namespace BLL
{
    public class PermissionBLL
    {
        private readonly PermissionDAL _permissionDAL = new PermissionDAL();

        public Result<int> AddPermission(SQLHelper.TransactionContext tran, Permission permission)
        {
            var res = _permissionDAL.AddPermission(tran,permission);
            return new Result<int>()
            {
                Code =  res > 0 ? 2000 : 5000,
                Message = res > 0 ? "添加成功" : "添加失败",
                Value = res
            };
        }

        public Result<int> AddModulePermission(SQLHelper.TransactionContext tran,ModulePermission modulePermission)
        {
            var res = _permissionDAL.AddModulePermission(tran,modulePermission);
            return new Result<int>()
            {
                Code =  res > 0 ? 2000 : 5000,
                Message = res > 0 ? "添加成功" : "添加失败",
                Value = res
            };
        }


    }
}