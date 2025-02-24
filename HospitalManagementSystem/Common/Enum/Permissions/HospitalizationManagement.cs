using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum HospitalizationManagement
    {
        //查看病房
        [PermissionMeta("查看病房", 25)]
        ViewWard = 1,
        //住院登记
        [PermissionMeta("住院登记", 26)]
        HospitalizationRegistration = 2,
        //查找病人
        [PermissionMeta("查找病人", 27)]
        FindPatient = 3,
        //出院结算
        [PermissionMeta("出院结算", 28)]
        OutPatientSettlement = 4,
        
    }
}