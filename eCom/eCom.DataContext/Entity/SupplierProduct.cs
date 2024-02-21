using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity
{
    public class SupplierProduct : BaseEntity
    {
        public Guid IdSupplier { get; set; }
        public Guid IdProduct { get; set; }
    }
}
