using System.Data;
using DAL;

namespace BLL
{
    public class ProductInfoBLL
    {
        private readonly ProductInfoDAL _productInfoDAL = new ProductInfoDAL();
        
        public DataTable GetProductInfoList()
        {
            return _productInfoDAL.GetProductInfoList();
        }

        public DataTable GetProductInfoListByCategory(int catId)
        {
            return _productInfoDAL.GetProductInfoListByCategory(catId);
        }

    }
}