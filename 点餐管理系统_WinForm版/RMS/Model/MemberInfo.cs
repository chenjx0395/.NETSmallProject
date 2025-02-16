using System;

namespace Model
{
    //会员信息
    public class MemberInfo
    {
        public int Mid { get; set; }
        public string Mname { get; set; }
        public string Gender { get; set; }
        public int Type { get; set; }
        public double Discount {  get; set; }
        public double Money { get; set; }
        public int Points {  get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNum { get; set; }
        public DateTime RegistDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemoveFlag {  get; set; }

    }
}