using System;
using System.Collections.Generic;
using System.Data;
using Common;
using DAL;
using Model;
using Model.DTO;

namespace BLL
{
    public class ModuleBLL
    {
        private readonly ModuleDAL _moduleDAL = new ModuleDAL();

        public Result<int> AddModule(Module module)
        {
            var res = _moduleDAL.AddModule(module);
            return new Result<int>()
            {
                Code =  res > 0 ? 2000 : 5000,
                Message = res > 0 ? "添加成功" : "添加失败"
            };
        }

        public Result<DataTable> GetModuleList()
        {
            var res = _moduleDAL.GetModuleList();
            return new Result<DataTable>()
            {
                Code = res.Rows.Count > 0 ? 2000 : 5000,
                Message = res.Rows.Count > 0 ? "获取成功" : "获取失败",
                Value = res
            };
        }

        //获取所有模块的权限信息
        public Result<List<ModulePermissionsDTO>> GetModulePermissionList()
        {
            //获取所有的模块ID
            var resData = new List<ModulePermissionsDTO>();
            try
            {
                var moduleList = _moduleDAL.GetModuleList();
                var moduleIds = new List<int>();
                foreach (DataRow row in moduleList.Rows)
                {
                    moduleIds.Add(Convert.ToInt32(row[0]));
                }
                foreach (var moduleId in moduleIds)
                {
                    var dataTable = _moduleDAL.GetModulePermissions(moduleId);
                    var modulePermission = new ModulePermissionsDTO
                    {
                        ModuleId = Convert.ToInt32(dataTable.Rows[0][0]),
                        Name = dataTable.Rows[0][1].ToString(),
                        Permissions = new List<Permission>()
                    };
                    foreach (DataRow row in dataTable.Rows)
                    {
                        modulePermission.Permissions.Add(new Permission
                        {
                            PermissionId = Convert.ToInt32(row[2]),
                            Name = row[3].ToString(),
                        });
                    }

                    resData.Add(modulePermission);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result<List<ModulePermissionsDTO>>()
                {
                    Code = 5000,
                    Message = "获取失败",
                };
            }
            return new Result<List<ModulePermissionsDTO>>()
            {
                Code = 2000,
                Message = "获取成功",
                Value = resData
            };
        }

    }
}