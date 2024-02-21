using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity
{
    public class Supplier : BaseEntity
    {
        public string SupplierCode { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string TaxCode { get; set; } //Mã số thuế
        public string Review { get; set; }
        public string Rated { get; set; } //Đánh giá nhà cung cấp
    }
}
