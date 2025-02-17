using System.Data;
using DAL;

namespace BLL
{
    public class RoomInfoBLL
    {
        private readonly RoomInfoDAL _roomInfoDal = new RoomInfoDAL();
        public DataTable GetRoomInfoList()
        {
            return _roomInfoDal.GetRoomInfoList();
        }

    }
}