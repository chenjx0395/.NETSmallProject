namespace DAL
{
    public class ModulePermission
    {
        public int MPId { get; set; }
        public int ModuleId { get; set; }
        public int PermissionId { get; set; }
        public bool IsRemove { get; set; } = false;
    }
}