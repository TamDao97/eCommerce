using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reservation.DataContext.Entity;

namespace Reservation.DataContext
{
    public class ReservationDbContext : IdentityDbContext<IdentityUser>
    {
        public ReservationDbContext()
        {
        }

        public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Entity.Reservation> Reservations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
