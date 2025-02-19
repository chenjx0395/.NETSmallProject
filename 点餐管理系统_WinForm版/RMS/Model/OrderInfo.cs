using System;

namespace Model
{
    public class OrderInfo
    {
        public int OrderId {  get; set; }
        public int OrderState {  get; set; }
        public DateTime SubTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Remark {  get; set; }
        public int NumberOfDiners {  get; set; }
        public int DelFlag {  get; set; }
        public double OrderMoney { get; set; }
        public double DisCount { get; set; }
    }
}
