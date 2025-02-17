using System.Data;
using System.Data.SQLite;
using Model;

namespace DAL
{
    public class CategoryInfoDAL
    {
        public int DeleteCategoryById(int id)
        {
            const string sql = @"update CategoryInfo set DelFlag = 1 where catid = @catId;";
            return SqLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@catId", id));
        }
        
        public int UpdateCategoryById(CategoryInfo categoryInfo)
        {
            const string sql = @"update CategoryInfo 
                                    set catname = @catname, remark = @remark , subtime = @subtime
                                    where catid = @catid;";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@catname", categoryInfo.CatName),
                new SQLiteParameter("@remark", categoryInfo.Remark),
                new SQLiteParameter("@subtime", categoryInfo.SubTime),
                new SQLiteParameter("@catid", categoryInfo.CatId)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }
        
        public DataTable GetCategoryInfoList()
        {
            const string sql = @"select catid, catname, remark, subtime  from CategoryInfo where DelFlag = 0;";
            return SqLiteHelper.ExecuteDataTable(sql);
        }

        public int InsertCategoryInfo(CategoryInfo categoryInfo)
        {
            const string sql = @"insert into CategoryInfo(catname, remark, subtime) 
                            values(@catname, @remark, @subtime);";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@catname", categoryInfo.CatName),
                new SQLiteParameter("@remark", categoryInfo.Remark),
                new SQLiteParameter("@subtime", categoryInfo.SubTime)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }
    }
}