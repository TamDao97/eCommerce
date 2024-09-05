using Reservation.API.DataContext.Entity.Base;

namespace Reservation.API.DataContext.Entity
{
    public class Permission : BaseEntity
    {
        public string ModuleCode { get; set; }
        public string ModuleDescription { get; set; }
        public int ModuleOrder { get; set; }

        public string PermissionCode { get; set; }
        public string? Description { get; set; }
    }
}
