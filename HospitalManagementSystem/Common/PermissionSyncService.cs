using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Common.Attribute;
using Common.Enum.Permissions;
using DAL;
using Model;

namespace Common
{
    //同步校验权限枚举和数据库枚举是否一致
    public class PermissionSyncService
    {
        //校验方法
        public void ValidatePermissions()
        {
            // 从数据库加载所有权限
            var dbPermissions = GetDbPermissions();

            // 获取枚举定义的所有权限
            var enumPermissions = GetEnumPermissions();

            // 验证双向匹配
            ValidateOneToOneMapping(dbPermissions, enumPermissions);
        }
        // 从数据库读取权限数据
        private List<Permission> GetDbPermissions()
        {
            var dataTable = new PermissionDAL().GetPermissionList();
            var rows = dataTable.Rows;
            var res = new List<Permission>();
            foreach (DataRow row in rows)
            {
                res.Add(new Permission
                {
                    PermissionId = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    Description = row[2].ToString(),
                });
            }
            return res;
        }

        //获取所有权限枚举数据
        private List<EnumPermission> GetEnumPermissions()
        {
            var list1 = GetEnumPermissionList(UserManagement.AddUser);
            var list2 = GetEnumPermissionList(SystemManagement.UpdatePermission);
            list2.AddRange(GetEnumPermissionList(OutpatientManagement.PatientRegistration));
            list2.AddRange(GetEnumPermissionList(OutpatientFees.FindPatient));
            list2.AddRange(GetEnumPermissionList(FinancialManagement.BusinessStatistics));
            list2.AddRange(GetEnumPermissionList(DrugStorehouseManagement.DrugStorehouseIn));
            list2.AddRange(GetEnumPermissionList(HospitalizationManagement.HospitalizationRegistration));
            list2.AddRange(GetEnumPermissionList(PharmacyManagement.ViewPickUpOrder));
            list2.AddRange(GetEnumPermissionList(OutpatientVisits.SelectPatient));

            List<EnumPermission> GetEnumPermissionList<TEumn>(TEumn enumType)
                where TEumn : System.Enum
            {
                return  System.Enum.GetValues(enumType.GetType())
                    .Cast<TEumn>()
                    .Select(p => new EnumPermission
                    {
                        EnumValue = p,
                        Meta = GetEnumAttribute<PermissionMetaAttribute>(p)
                    })
                    .ToList();
            }
            return list1.Concat(list2).ToList();
        }
        
        //获取枚举的特性
        public  TAttribute GetEnumAttribute<TAttribute>(System.Enum enumValue) 
            where TAttribute : System.Attribute
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString()).FirstOrDefault();
    
            return memberInfo?.GetCustomAttribute<TAttribute>(false);
        }

        //双向比较
        private void ValidateOneToOneMapping(List<Permission> db, List<EnumPermission> enums)
        {
            // 检查数据库有而枚举没有的权限
            var missingInEnum = db.Where(d => enums.All(e => e.Meta.DBId != d.PermissionId))
                .ToList();

            // 检查枚举有而数据库没有的权限
            var missingInDb = enums.Where(e => db.All(d => d.PermissionId != e.Meta.DBId))
                .ToList();

            if (missingInEnum.Any() || missingInDb.Any())
            {
                var errorMsg = new StringBuilder("权限同步异常：\n");
                missingInEnum.ForEach(p =>
                    errorMsg.AppendLine($"数据库中存在未定义的权限 ID:{p.PermissionId} Name:{p.Name}"));
                missingInDb.ForEach(p =>
                    errorMsg.AppendLine($"枚举中存在无效的权限 {p.Meta.PermissionName}"));

                throw new Exception(errorMsg.ToString());
            }
        }
    }
    
    public class EnumPermission
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public System.Enum EnumValue { get; set; }

        public PermissionMetaAttribute Meta { get; set; }
    }
}

