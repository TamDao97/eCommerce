using Microsoft.AspNetCore.Identity;
using Reservation.DataContext.Entity.Base;

namespace Reservation.DataContext.Entity.Extends
{
    public class User : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
