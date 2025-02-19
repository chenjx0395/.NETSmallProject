using System.Data;
using DAL;
using Model;
using Model.DTO;

namespace BLL
{
    public class MemberInfoBLL
    {
        private readonly MemberInfoDAL _memberInfoDal = new MemberInfoDAL();

        public int DeleteMemberInfoById(int id)
        {
            return _memberInfoDal.DeleteMemberInfoById(id);
        }
        
        public QueryMemberDTO PagingQuery(int pageIndex, int pageSize)
        {
            return _memberInfoDal.PagingQuery(pageIndex, pageSize);
        }
        
        //插入会员数据
        public int InsertMemberInfo(MemberInfo memberInfo)
        {
            return _memberInfoDal.InsertMemberInfo(memberInfo);
        }

        public DataTable GetMemberInfoById(int id)
        {
            return _memberInfoDal.GetMemberInfoById(id);
        }
        
        //根据会员名称模糊查询
        public DataTable LikeGetMemberInfoByName(string name)
        {
            return _memberInfoDal.LikeGetMemberInfoByName(name);
        }

        public int UpdateMemberInfo(MemberInfo memberInfo)
        {
            return _memberInfoDal.UpdateMemberInfo(memberInfo);
        }



    }
}