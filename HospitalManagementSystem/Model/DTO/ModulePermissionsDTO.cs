using System.Collections.Generic;

namespace Model.DTO
{
    public class ModulePermissionsDTO
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}