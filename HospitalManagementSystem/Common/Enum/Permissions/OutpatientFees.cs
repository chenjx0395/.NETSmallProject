using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum OutpatientFees
    {
        //查找
        [PermissionMeta("查找", 29)]
        FindPatient = 1,
        //门诊结账
        [PermissionMeta("门诊结账", 30)]
        OutPatientSettlement = 2
        
    }
}