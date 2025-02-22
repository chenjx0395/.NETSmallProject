namespace Model
{
    public class Module
    {
            public int ModuleId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsRemove { get; set; } = false;
            
    }
}