using System;

namespace Model
{
    public class ProductInfo
    {
        public int ProId {  get; set; }
        public int CatId { get; set; }
        public string ProName { get; set; }
        public double ProCost {  get; set; }
        public string ProShell {  get; set; }
        public double ProPrice { get; set; }
        public string ProUnit {  get; set; }
        public string Remark {  get; set; }
        public int DelFlag {  get; set; }
        public DateTime SubTime { get; set; }
        public double ProStock {  get; set; }
    }
}
