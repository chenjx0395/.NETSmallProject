using System.Data;

namespace Model.DTO
{
    public class QueryMemberDTO
    {
       public DataTable MemberInfos { get; set; }
       /// <summary>
       /// 会员数据分页后的总页数
       /// </summary>
       public int PageCount { get; set; }
    }
}