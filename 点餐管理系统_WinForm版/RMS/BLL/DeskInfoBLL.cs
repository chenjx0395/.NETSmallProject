using System.Data;
using DAL;

namespace BLL
{
    public class DeskInfoBLL
    {
        private readonly DeskInfoDAL _deskInfoDAL = new DeskInfoDAL();
        public DataTable GetDeskInfoByRoomId(int roomId)
        {
            return _deskInfoDAL.GetDeskInfoByRoomId(roomId);
        }

    }
}