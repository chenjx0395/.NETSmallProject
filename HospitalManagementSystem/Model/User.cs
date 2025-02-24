using System;

namespace Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Account { get; set; }
        
        public string Password { get; set; }

        public string Sex { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Spell { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsRemove { get; set; } = false;
        public string Name { get; set; }
    }
}