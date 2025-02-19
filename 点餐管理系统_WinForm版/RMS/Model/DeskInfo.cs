using System;


namespace Model
{
    public class DeskInfo 
    {
        public int DeskId {  get; set; }
        public int RoomId { get; set; }
        public string DeskName { get; set; }
        public string DeskRemark {  get; set; }
        public int DeskState { get; set; }
        public int DelFlag { get; set; }
        public DateTime SunTime { get; set; }
    }
}
