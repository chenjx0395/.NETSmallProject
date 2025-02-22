namespace Model
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRemove { get; set; } = false;
    }

}