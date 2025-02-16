using System.Data;

namespace DAL
{
    public class MemberTypeDAL
    {
        public DataTable GetMemberTypeList()
        {
            return SqLiteHelper.ExecuteDataTable("SELECT tid, tname,description FROM MemberType;");
        }
    }
}