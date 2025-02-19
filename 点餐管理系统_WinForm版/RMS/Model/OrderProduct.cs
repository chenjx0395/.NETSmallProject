using System;

namespace Model
{
    public class OrderProduct
    {
        public int OrderProId { get; set; }
        public int OrderId { get; set; }
        public int ProId { get; set; }
        public int ProCount { get; set; }
        public DateTime SubTime { get; set; }
        public int DelFlag { get; set; }
    }
}