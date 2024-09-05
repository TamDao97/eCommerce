using Microsoft.AspNetCore.Identity;
using TD.Lib.Common;

namespace Reservation.API.DataContext.Dto.Extends
{
    public class ApplicationRoleDto : IdentityRole<Guid>
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

    public class RoleGridFilter : GridFilterBase
    {

    }
}
