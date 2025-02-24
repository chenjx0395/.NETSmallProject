using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum OutpatientManagement
    {
        //病人挂号
        [PermissionMeta("病人挂号", 15)]
        PatientRegistration = 1,
        //代办医疗卡
        [PermissionMeta("代办医疗卡", 16)]
        PatientCard = 2,
        //退号
        [PermissionMeta("退号", 18)]
        PatientCancel = 3,
        //挂号表查询
        [PermissionMeta("挂号表查询", 19)]
        PatientRegistrationQuery = 4,
        //医疗卡补办
        [PermissionMeta("医疗卡补办", 20)]
        PatientCardReissue = 5,
        
    }
}