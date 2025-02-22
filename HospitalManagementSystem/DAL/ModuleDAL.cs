using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ModuleDAL
    {
        //添加模块
        public int AddModule(Module module)
        {
            const string sql = @"insert into Module(Name,Description,IsRemove) values(@Name,@Description,@IsRemove)";
            return SQLHelper.ExecuteNonQuery(sql, 
                new SqlParameter("@Name", module.Name)
                , new SqlParameter("@Description", module.Description)
                , new SqlParameter("@IsRemove", module.IsRemove));
        }
        //获取模块列表
        public DataTable GetModuleList()
        {
            const string sql = @"select moduleid, name, description, isremove from Module where IsRemove=0";
            return SQLHelper.FillDataTable(sql);
        }
    }
}