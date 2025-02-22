using System;

namespace Common.Attribute
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PermissionMetaAttribute : System.Attribute
    {
        public string PermissionName { get; }
        public int DBId { get; }
        public PermissionMetaAttribute(string permissionName, int dbId)
        {
            PermissionName = permissionName;
            DBId = dbId;
        }
    }
}