using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity.OrderSite
{
    public class UserRole : BaseEntity
    {
        public Guid IdUser { get; set; }
        public Guid IdRole { get; set; }
    }
}
