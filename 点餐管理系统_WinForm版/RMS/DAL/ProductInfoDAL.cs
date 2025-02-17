using System.Data;
using System.Data.SQLite;

namespace DAL
{
    public class ProductInfoDAL
    {
        public DataTable GetProductInfoList()
        {
            const string sql = @"select proid, proname, procost, prospell, proprice, prounit, remark, subtime, prostock 
                            from ProductInfo 
                            where DelFlag = 0;";
            return SqLiteHelper.ExecuteDataTable(sql);
        }

        public DataTable GetProductInfoListByCategory(int catId)
        {
            var sql = @"select proid, proname, procost, prospell, proprice, prounit, remark, subtime, prostock
                        from ProductInfo
                        where DelFlag = 0 and catid = @catid;";
            return SqLiteHelper.ExecuteDataTable(sql, new SQLiteParameter("@catid", catId));
        }
        
    }
}