using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum UserManagement
    {
        
        [PermissionMeta("添加用户", 11)]
        AddUser = 1,
        [PermissionMeta("修改用户", 12)]
        UpdateUser= 2,
        [PermissionMeta("删除用户", 13)]
        DeleteUser = 4,
        [PermissionMeta("查询用户", 14)]
        SelectUser = 8,
    }
}