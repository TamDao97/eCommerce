using Reservation.DataContext;

namespace Reservation.UnitOfWork
{
    public interface IUnitOfWork : Base.Lib.Repository.IUnitOfWork, IDisposable
    {
    }

    public class UnitOfWork : Base.Lib.Repository.UnitOfWork, IUnitOfWork
    {
        ReservationDbContext _reservationDbContext;
        public UnitOfWork(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }
    }
}
