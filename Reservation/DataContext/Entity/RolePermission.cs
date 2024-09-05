using Reservation.API.DataContext.Entity.Base;

namespace Reservation.API.DataContext.Entity
{
    public class RolePermission : BaseEntity
    {
        public Guid IdRole { get; set; }
        public Guid IdPermission { get; set; }
    }
}
