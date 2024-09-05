using Microsoft.AspNetCore.Identity;

namespace Reservation.API.DataContext.Entity.Extends
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Code { get; set; }
        public string? Description { get; set; }

        //base fields 
        public DateTime DateCreated { get; set; }
        public DateTime DateModify { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid ModifyUserId { get; set; }
        public bool IsDeleted { get; set; }
        public int Order { get; set; }
    }
}
