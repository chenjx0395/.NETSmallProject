namespace Model
{
    public class RolePermission
    {
        public int RPId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool IsRemove { get; set; }
    }
}