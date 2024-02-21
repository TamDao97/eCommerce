using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity
{
    public class InventoryReceiptDetail : BaseEntity
    {
        public Guid IdInventoryReceipt { get; set; }
        public Guid IdProduct { get; set; }
        public string Quantity { get; set; } //Số lượng
    }
}
