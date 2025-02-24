using Common.Attribute;

namespace Common.Enum.Permissions
{
    public enum FinancialManagement 
    {
        //营业统计
        [PermissionMeta("营业统计", 21)]
        BusinessStatistics = 1,
        //工资分配
        [PermissionMeta("工资分配", 22)]
        SalaryDistribution = 2,
    }
}