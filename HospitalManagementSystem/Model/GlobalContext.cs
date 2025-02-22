using Model.DTO;

namespace Model
{
    public class GlobalContext
    {
        public static UserPermissionsDTO CurrentUser { get; set; }
    }
}