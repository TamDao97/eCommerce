using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity.OrderSite
{
    public class UserProfile : BaseEntity
    {
        public Guid IdUser { get; set; }
        public string DisplayName { get; set; }
        public string Old { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
    }
}
