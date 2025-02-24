using System;
using System.Collections.Generic;

namespace Model.DTO
{
    public class UserPermissionsDTO
    {
        public List<int> UserPermissions { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public bool HasPermission(int code)
        {
            return UserPermissions.Contains(code);
        }
        
    }
}