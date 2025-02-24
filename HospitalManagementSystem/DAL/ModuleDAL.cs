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
        
        //根据模块id查询其下的权限
        public DataTable GetModulePermissions(int moduleId)
        {
            const string sql = @"select m.ModuleId , m.Name, p.permissionid, p.name from module  m
                             join modulePower mp  on m.ModuleId= mp.ModuleId
                            join permission p on p.permissionid=mp.permissionid
                            where m.moduleid=@moduleId and m.isremove=0";
            return SQLHelper.FillDataTable(sql, new SqlParameter("@ModuleId", moduleId));
        }
    }
}