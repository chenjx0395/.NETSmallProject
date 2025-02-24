using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum OutpatientVisits
    {
        //选病人
        [PermissionMeta("选病人", 35)]
        SelectPatient = 1,
        //写病历
        [PermissionMeta("写病历", 36)]
        WriteMedicalRecord = 2,
        //开中药
        [PermissionMeta("开中药", 37)]
        OpenMedicine = 3,
        //开西药
        [PermissionMeta("开西药", 38)]
        OpenWestMedicine = 4,
    }
}