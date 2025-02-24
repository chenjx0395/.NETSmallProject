using System;
using System.Collections.Generic;
using System.Data;
using Common;
using Common.Attribute;
using Common.Constant.LogFlag;
using DAL;
using Model;

namespace BLL
{
    public class RoleBLL  : MarshalByRefObject
    {
        private readonly RoleDAL _roleDAL = new RoleDAL();
        
        //定义返回代理对象的构造函数
        public static RoleBLL GetRoleBLLProxy()
        {
            var roleBLL = new RoleBLL();
            //创建代理对象
            var proxy = new PermissionLoggingProxy<RoleBLL>(roleBLL);
            //将代理对象赋值给本类
             return proxy.GetTransparentProxy() as RoleBLL;
        }
        
        public Result<DataTable> GetRoleList()
        {
            var dataTable = _roleDAL.GetRoleList();
            if (dataTable == null)
            {
                return new Result<DataTable>()
                {
                    Code = 5000,
                    Message = "获取角色列表失败"
                };
            }
            else
            {
                return new Result<DataTable>()
                {
                    Code = 2000,
                    Message = "获取角色列表成功",
                    Value = dataTable
                };
            }
        }
        // 新建角色
        [PermissionOperationLog(ActionTypeConstant.Add, TargetTypeConstant.Role)]
        public Result<int> AddRole(Role role,List<int> permissionIds)
        {
           //启用事务
           using ( var tran = SQLHelper.BeginTransaction())
           {
               try
               {
                   //添加角色，获取新增ID
                   var resId = _roleDAL.AddRole(tran,role);
                   //批量添加角色权限关系表数据
                   foreach (var pId in permissionIds)
                   {
                       var addRolePermission = _roleDAL.AddRolePermission(tran,new RolePermission()
                       {
                           RoleId = resId,
                           PermissionId = pId
                       });
                       if (addRolePermission < 1) throw new Exception("添加角色权限关系表数据错误") ;
                   }
                   tran.Commit();
               }
               catch (Exception e)
               {
                   Console.WriteLine(e);
                   tran.Rollback();
                   return new Result<int>()
                   {
                       Code = 5000,
                       Message = "添加角色失败"
                   };
               }
           }
           return new Result<int>()
           {
               Code = 2000,
               Message = "添加角色成功",
               Value = 1
           };
        }

        public Result<List<int>> GetRolePermissions(int roleId)
        {
            var dataTable = _roleDAL.GetRolePermissions(roleId);
            var res = new List<int>();      
            foreach (DataRow row in dataTable.Rows)
            {
                res.Add(Convert.ToInt32(row[0]));
            }
            return new Result<List<int>>()
            {
                Code = 2000,
                Message = "获取角色权限成功",
                Value = res
            };
        }


    }
}