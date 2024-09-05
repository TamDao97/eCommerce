using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reservation.API.DataContext.Entity;
using Reservation.API.DataContext.Entity.Extends;

namespace Reservation.API.DataContext
{
    public class ReservationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ReservationDbContext()
        {
        }

        public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Entity.Reservation> Reservations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
