using DAL;
using Model;

namespace BLL
{
    public class OrderInfoBLL
    {
        private readonly OrderInfoDAL _orderInfoDAL = new OrderInfoDAL();
        public int InsertOrderAndGetId(OrderInfo orderInfo)
        {
            return _orderInfoDAL.InsertOrderAndGetId(orderInfo);
        }

        public int InsertOrderDesk(int orderId, int deskId)
        {
            return _orderInfoDAL.InsertOrderDesk(orderId, deskId);
        }
    }
}