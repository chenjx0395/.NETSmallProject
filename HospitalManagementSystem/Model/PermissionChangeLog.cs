using System;

namespace Model
{
    public class PermissionChangeLog
    {
        public int PCLId { get; set; }
        public int FromUserId { get; set; }
        public string TargetType { get; set; }
        public string ActionType { get; set; }
        public string Details { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}