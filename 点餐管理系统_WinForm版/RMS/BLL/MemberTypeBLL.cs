using System.Data;
using DAL;

namespace BLL
{
    public class MemberTypeBLL
    {
        private readonly MemberTypeDAL _memberTypeDAL = new MemberTypeDAL();
            public DataTable GetMemberTypeList()
            {
                return _memberTypeDAL.GetMemberTypeList();
            }
        
    }
}