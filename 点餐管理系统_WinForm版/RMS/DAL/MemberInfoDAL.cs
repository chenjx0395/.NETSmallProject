using System;
using System.Data;
using System.Data.SQLite;
using System.Runtime.InteropServices.WindowsRuntime;
using Model;
using Model.DTO;

namespace DAL
{
    public class MemberInfoDAL
    {

        public int UpdateMemberInfo(MemberInfo memberInfo)
        {
            string sql = @"update MemberInfo 
                            set mname = @mname, gender = @gender, type = @type, discount = @discount, 
                                money = @money, points = @points, birthday = @birthday, 
                                phoneNum = @phoneNum, registDate = @registDate, endDate = @endDate 
                            where mid = @mid;";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@mid", memberInfo.Mid),
                new SQLiteParameter("@mname", memberInfo.Mname),
                new SQLiteParameter("@gender", memberInfo.Gender),
                new SQLiteParameter("@type", memberInfo.Type),
                new SQLiteParameter("@discount", memberInfo.Discount),
                new SQLiteParameter("@money", memberInfo.Money),
                new SQLiteParameter("@points", memberInfo.Points),
                new SQLiteParameter("@birthday", memberInfo.Birthday),
                new SQLiteParameter("@phoneNum", memberInfo.PhoneNum),
                new SQLiteParameter("@registDate", memberInfo.RegistDate),
                new SQLiteParameter("@endDate", memberInfo.EndDate)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }
        
        public DataTable LikeGetMemberInfoByName(string name)
        {
            string slq = @"select * from MemberInfo where mname like @name";
            return SqLiteHelper.ExecuteDataTable(slq, new SQLiteParameter("@name", "%" + name + "%"));
        }

        public DataTable GetMemberInfoById(int id)
        {
            string sql = @"select * from MemberInfo where mid = @mid;";
            return SqLiteHelper.ExecuteDataTable(sql, new SQLiteParameter("@mid", id));
        }

        public int DeleteMemberInfoById(int id)
        {
            string sql = @"update MemberInfo set removeFlag = 1 where mid = @mid;";
            return SqLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@mid", id));
        }
        
        public int InsertMemberInfo(MemberInfo memberInfo)
        {
            string sql = @"
                            INSERT INTO MemberInfo (
                            mname, gender, type, discount, money, points, birthday, phoneNum, 
                                                    registDate, endDate, removeFlag
                            ) VALUES (
                            @mname, @gender, @type, @discount, @money, @points, @birthday, 
                                   @phoneNum, @registDate, @endDate, @removeFlag
                                 );";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@mname", memberInfo.Mname),
                new SQLiteParameter("@gender", memberInfo.Gender),
                new SQLiteParameter("@type", memberInfo.Type),
                new SQLiteParameter("@discount", memberInfo.Discount),
                new SQLiteParameter("@money", memberInfo.Money),
                new SQLiteParameter("@points", memberInfo.Points),
                new SQLiteParameter("@birthday", memberInfo.Birthday),
                new SQLiteParameter("@phoneNum", memberInfo.PhoneNum),
                new SQLiteParameter("@registDate", memberInfo.RegistDate),
                new SQLiteParameter("@endDate", memberInfo.EndDate),
                new SQLiteParameter("@removeFlag", memberInfo.RemoveFlag)
            };
            var result = SqLiteHelper.ExecuteNonQuery(sql, parameters);
            return result;

        }
        
        public QueryMemberDTO PagingQuery(int pageIndex, int pageSize)
        {
            //根据页码和每页数量获取会员数据
            string sql = @"SELECT mid,
                                  mname,
                                  gender,
                                  type,
                                  discount,
                                  money,
                                  points,
                                  birthday,
                                  phoneNum,
                                  registDate,
                                  endDate
                            FROM MemberInfo 
                            where removeFlag = 0
                            limit @pageIndex , @pageSize";
            // 调整pageIndex
            pageIndex = (pageIndex - 1) * pageSize;
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@pageIndex", pageIndex),
                new SQLiteParameter("@pageSize", pageSize)
            };
            var dataTable = SqLiteHelper.ExecuteDataTable(sql,parameters);
            string sql2 = @"select ceiling(count(mid) * 1.0 / @pageSize ) 
                            from MemberInfo 
                            where removeFlag = 0";
            var count = Convert.ToInt32(SqLiteHelper.ExecuteScalar(sql2, parameters[1]));
            return new QueryMemberDTO
            {
                MemberInfos = dataTable,
                PageCount = count
            };
        }
    }
}
