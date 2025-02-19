using System;
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
    }
}