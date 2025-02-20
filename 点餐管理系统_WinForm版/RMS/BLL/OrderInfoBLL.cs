using System.Data;
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

        public DataTable GetOrderProductByOrderId(int orderId)
        {
            return _orderInfoDAL.GetOrderProductByOrderId(orderId);
        }

        public int InsertOrderProduct(OrderProduct orderProduct)
        {
            return _orderInfoDAL.InsertOrderProduct(orderProduct);
        }

        public int UpdateOrderProductCount(OrderProduct orderProduct)
        {
            return _orderInfoDAL.UpdateOrderProductCount(orderProduct);
        }

        public int GetOrderIdByDeskId(int deskId)
        {
            return _orderInfoDAL.GetOrderIdByDeskId(deskId);
        }

        public int GetProductCountByOrderIdAndProductId(int orderId, int productId)
        {
            return _orderInfoDAL.GetProductCountByOrderIdAndProductId(orderId, productId);
            
        }

        public int DecreaseProductCountByOrderIdAndProductId(int orderId, int productId)
        {
            return _orderInfoDAL.DecreaseProductCountByOrderIdAndProductId(orderId, productId);
        }

        public int DeleteOrderProductByOrderIdAndProductId(int orderId, int productId)
        {
            return _orderInfoDAL.DeleteOrderProductByOrderIdAndProductId(orderId, productId);
        }




    }
}