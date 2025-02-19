using System;

namespace Model.DTO
{
    public class AddOrderDeskDTO : EventArgs
    {
        public string RoomName { get; set; }
        public string DeskName { get; set; }
        public int RoomMinConsumption { get; set; }
        public int RoomId { get; set; }
        public int DeskId { get; set; }
        public int OrderId { get; set; }
    }
}