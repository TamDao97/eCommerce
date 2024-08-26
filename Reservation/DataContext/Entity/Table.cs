using Reservation.DataContext.Entity.Base;

namespace Reservation.DataContext.Entity
{
    public class Table : BaseEntity
    {
        public string TableCode { get; set; }
        public string TableName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public int LimitNumber { get; set; }
        public int Status { get; set; }
    }
}
