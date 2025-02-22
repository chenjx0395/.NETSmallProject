using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum SystemManagement 
    {
        [PermissionMeta("修改权限", 3)]
        UpdatePermission = 1,
        
    }
}