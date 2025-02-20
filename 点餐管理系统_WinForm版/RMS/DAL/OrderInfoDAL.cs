using System;
using System.Data;
using System.Data.SQLite;
using Model;

namespace DAL
{
    public class OrderInfoDAL
    {
        //新增订单，获取新增的订单ID
        public int InsertOrderAndGetId(OrderInfo orderInfo)
        {
            const string sql = @"insert into OrderInfo(SubTime, Remark, NumberOfDiners) 
                                    values (@SubTime, @Remark, @PersonCount) ;
                                    SELECT last_insert_rowid();";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@SubTime", orderInfo.SubTime),
                new SQLiteParameter("@Remark", orderInfo.Remark),
                new SQLiteParameter("@PersonCount", orderInfo.NumberOfDiners)
            };
            Console.WriteLine(SqLiteHelper.ExecuteScalar(sql, parameters));
            return Convert.ToInt32(SqLiteHelper.ExecuteScalar(sql, parameters));
        }
        
        // 新增订单-桌面关系表
        public int InsertOrderDesk(int orderId, int deskId)
        {
            const string sql = "insert into Order_Desk(orderId,deskId ) values  (@orderId,@deskId);";
            SQLiteParameter[] parameters = new[]
            {
                new SQLiteParameter("@orderId", orderId),
                new SQLiteParameter("@deskId", deskId)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }
            
        // 根据订单ID获取相关商品信息
        public DataTable GetOrderProductByOrderId(int orderId)
        {
            const string sql =
                @"select p.proid , proname , o.ProCount, proprice, prounit, 
                        proprice*o.ProCount totalPrice , c.CatName, o.SubTime
                                from ProductInfo p 
                                join CategoryInfo c on p.CatId = c.CatId
                                join Order_Product o on p.ProId = o.ProId
                                where o.OrderId = @orderId and o.DelFlag = 0;";
            return SqLiteHelper.ExecuteDataTable(sql, new SQLiteParameter("@orderId", orderId));
        }
        
        //添加商品到订单中
        public int InsertOrderProduct(OrderProduct orderProduct)
        {
            const string sql = @"insert into Order_Product(OrderId, ProId, ProCount, SubTime) 
                                    values (@OrderId, @ProId, @ProCount, @SubTime);";
            return SqLiteHelper.ExecuteNonQuery(sql, new[]
            {
                new SQLiteParameter("@OrderId", orderProduct.OrderId),
                new SQLiteParameter("@ProId", orderProduct.ProId),
                new SQLiteParameter("@ProCount", orderProduct.ProCount),
                new SQLiteParameter("@SubTime", orderProduct.SubTime)
            });
        }
        // 修改订单商品表的商品数量
        public int UpdateOrderProductCount(OrderProduct orderProduct)
        {
            const string sql = @"update Order_Product set ProCount = ProCount+1 where OrderId = @OrderId and ProId = @ProId;";
            return SqLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@OrderId", orderProduct.OrderId),
                new SQLiteParameter("@ProId", orderProduct.ProId));
        }
        
        // 查询此桌面最新的订单号
        public int GetOrderIdByDeskId(int deskId)
        {
            const string sql = @"select OrderId 
                                    from Order_Desk 
                                    where  DeskId = @deskId
                                    order by OrderId desc 
                                    limit 0 , 1;
";
            return Convert.ToInt32(SqLiteHelper.ExecuteScalar(sql, new SQLiteParameter("@deskId", deskId)));
        }
        
        // 查询指定订单的指定商品数量
        public int GetProductCountByOrderIdAndProductId(int orderId, int productId)
        {
            const string sql = @"select ProCount 
                                    from Order_Product 
                                    where OrderId = @orderId and ProId = @productId and DelFlag = 0;";
            SQLiteParameter[] parameters = new[]
            {
                new SQLiteParameter("@orderId", orderId),
                new SQLiteParameter("@productId", productId)
            };
            return Convert.ToInt32(SqLiteHelper.ExecuteScalar(sql, parameters));
        }
        
        // 减少一个数量，根据订单id和商品id
        public int DecreaseProductCountByOrderIdAndProductId(int orderId, int productId)
        {
            const string sql = @"update Order_Product set ProCount = ProCount-1 where OrderId = @orderId and ProId = @productId and DelFlag = 0;";
            return SqLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@orderId", orderId),
                new SQLiteParameter("@productId", productId));
        }
        
        // 删除订单的商品，根据订单id和商品id
        public int DeleteOrderProductByOrderIdAndProductId(int orderId, int productId)
        {
            const string sql = @"update Order_Product set DelFlag = 1 where OrderId = @orderId and ProId = @productId and DelFlag = 0;";
            return SqLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@orderId", orderId),
                new SQLiteParameter("@productId", productId));
        }
        
        // 修改订单状态，将其置为已结账状态
        public int UpdateOrderState(OrderInfo orderInfo)
        {
            const string sql = @"update OrderInfo 
                                    set OrderState = 1 , EndTime = @endTime , OrderMoney = @orderMoney , DisCount =  @disCount 
                                    where OrderId = @orderId;";
            return SqLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@orderId", orderInfo.OrderId),
                new SQLiteParameter("@endTime", orderInfo.EndTime),
                new SQLiteParameter("@orderMoney", orderInfo.OrderMoney),
                new SQLiteParameter("@disCount", orderInfo.DisCount));
        }
    }
}