namespace Model
{
    public class UserInfo
    {
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
    }
}