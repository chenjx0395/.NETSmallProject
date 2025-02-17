using System;


namespace Model
{
    public class CategoryInfo : EventArgs
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string Remark {  get; set; }
        public int DelFlag { get; set; }
        public DateTime SubTime { get; set; }
    }
}
