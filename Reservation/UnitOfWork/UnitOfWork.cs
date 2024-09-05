using Reservation.API.DataContext;

namespace Reservation.API.UnitOfWork
{
    public interface IUnitOfWork : TD.Lib.Repository.IUnitOfWork, IDisposable
    {
    }

    public class UnitOfWork : TD.Lib.Repository.UnitOfWork, IUnitOfWork
    {
        ReservationDbContext _reservationDbContext;
        public UnitOfWork(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }
    }
}
