using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity.OrderSite
{
    public class ProductProperties : BaseEntity
    {
        public Guid IdProduct { get; set; }
        public Guid IdProperties { get; set; }
    }
}
