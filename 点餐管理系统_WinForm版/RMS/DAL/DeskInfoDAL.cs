using System.Data;
using System.Data.SQLite;

namespace DAL
{
    public class DeskInfoDAL
    {
        public DataTable GetDeskInfoByRoomId(int roomId)
        {
            const string sql =
                @"select DeskId, RoomId, DeskName, DeskRemark, DeskState, SubTime 
                    from DeskInfo 
                    where DelFlag = 0 and roomid = @roomId;";
            return SqLiteHelper.ExecuteDataTable(sql, new SQLiteParameter("@roomId", roomId));
        }
    }
}