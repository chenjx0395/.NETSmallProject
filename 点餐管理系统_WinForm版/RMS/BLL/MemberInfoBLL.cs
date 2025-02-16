using System.Data;
using DAL;
using Model;
using Model.DTO;

namespace BLL
{
    public class MemberInfoBLL
    {
        private readonly MemberInfoDAL MemberInfoDal = new MemberInfoDAL();

        public int DeleteMemberInfoById(int id)
        {
            return MemberInfoDal.DeleteMemberInfoById(id);
        }
        
        public QueryMemberDTO PagingQuery(int pageIndex, int pageSize)
        {
            return MemberInfoDal.PagingQuery(pageIndex, pageSize);
        }

        /// <summary>
        /// 插入会员数据
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int InsertMemberInfo(MemberInfo memberInfo)
        {
            return MemberInfoDal.InsertMemberInfo(memberInfo);
        }

        public DataTable GetMemberInfoById(int id)
        {
            return MemberInfoDal.GetMemberInfoById(id);
        }

        /// <summary>
        /// 根据会员名称模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable LikeGetMemberInfoByName(string name)
        {
            return MemberInfoDal.LikeGetMemberInfoByName(name);
        }


    }
}