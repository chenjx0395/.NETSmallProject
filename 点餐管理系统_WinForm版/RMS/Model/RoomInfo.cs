using System;

namespace Model
{
    public class RoomInfo
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int RoomMinConsumption { get; set; }
        public int DelFlag {  get; set; }
        public DateTime SubTime { get; set; }
    }
}
