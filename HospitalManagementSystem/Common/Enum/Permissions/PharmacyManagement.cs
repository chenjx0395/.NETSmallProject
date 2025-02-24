using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum PharmacyManagement
    {
        //查看拾药单
        [PermissionMeta("查看拾药单", 23)]
        ViewPickUpOrder = 1,
        //查看已发药品
        [PermissionMeta("查看已发药品", 24)]
        ViewSendOutDrug = 2,
    }
}