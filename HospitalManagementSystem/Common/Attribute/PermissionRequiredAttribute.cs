using System;
using System.Collections.Generic;

namespace Common.Attribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionRequiredAttribute : System.Attribute
    {
        public Type EnumType { get; }
        public object[] Enums { get; }
        public List<int> PermissionId { get; }

        public PermissionRequiredAttribute(Type enumType, params object[] enums)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("必须是枚举类型");
            
            EnumType = enumType;
            Enums = enums;
            PermissionId = new List<int>();
            var permissionSyncService = new PermissionSyncService();    
            foreach (var e in enums)
            {
                //转换成对应的枚举类型
                var permissionMetaAttribute = permissionSyncService.GetEnumAttribute<PermissionMetaAttribute>((System.Enum)e);
                PermissionId.Add(permissionMetaAttribute.DBId);
            }
        }
    }
    
}