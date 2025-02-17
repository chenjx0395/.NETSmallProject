using System.Data;

namespace DAL
{
    public class RoomInfoDAL
    {
        public DataTable GetRoomInfoList()
        {
            const string sql = "select roomid, roomname, roomminconsumption, subtime from RoomInfo where DelFlag = 0;";
            return SqLiteHelper.ExecuteDataTable(sql);
        }
    }
}