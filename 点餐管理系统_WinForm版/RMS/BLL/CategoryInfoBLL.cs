using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class CategoryInfoBLL
    {
        private readonly CategoryInfoDAL _categoryInfoDAL = new CategoryInfoDAL();
        public DataTable GetCategoryInfoList()
        {
            return _categoryInfoDAL.GetCategoryInfoList();
        }

        public int InsertCategoryInfo(CategoryInfo categoryInfo)
        {
            return _categoryInfoDAL.InsertCategoryInfo(categoryInfo);
        }

        public int UpdateCategoryById(CategoryInfo categoryInfo)
        {
            return _categoryInfoDAL.UpdateCategoryById(categoryInfo);
        }

        public int DeleteCategoryById(int id)
        {
            return _categoryInfoDAL.DeleteCategoryById(id);
        }


    }
}