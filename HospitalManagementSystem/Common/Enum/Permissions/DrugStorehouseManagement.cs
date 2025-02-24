using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum DrugStorehouseManagement
    {
        //药品入库
        [PermissionMeta("药品入库", 31)]
        DrugStorehouseIn = 1,
        //药品出库
        [PermissionMeta("药品出库", 32)]
        DrugStorehouseOut = 2,
        //药品查看
        [PermissionMeta("药品查看", 33)]
        DrugStorehouseView = 3,
        //药品报警
        [PermissionMeta("药品报警", 34)]
        DrugStorehouseAlarm = 4,
    }
}