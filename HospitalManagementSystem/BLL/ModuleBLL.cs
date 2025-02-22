using System.Data;
using Common;
using DAL;
using Model;

namespace BLL
{
    public class ModuleBLL
    {
        private readonly ModuleDAL _moduleDAL = new ModuleDAL();

        public Result<int> AddModule(Module module)
        {
            var res = _moduleDAL.AddModule(module);
            return new Result<int>()
            {
                Code =  res > 0 ? 2000 : 5000,
                Message = res > 0 ? "添加成功" : "添加失败"
            };
        }

        public Result<DataTable> GetModuleList()
        {
            var res = _moduleDAL.GetModuleList();
            return new Result<DataTable>()
            {
                Code = res.Rows.Count > 0 ? 2000 : 5000,
                Message = res.Rows.Count > 0 ? "获取成功" : "获取失败",
                Value = res
            };
        }

    }
}