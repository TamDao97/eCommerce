using eCom.DataContext.Entity.Base;
using eCom.DataContext.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity
{
    /// <summary>
    /// Biên lai thu/chi
    /// </summary>
    public class Receipt : BaseEntity
    {
        public Guid IdUser { get; set; }
        public Guid IdPurchaseOrder { get; set; } //Id Phiếu nhập
        public Guid IdSalesOrder { get; set; } //Id Phiếu xuất 
        public ReceiptType ReceiptType { get; set; } //Loại phiếu
        public PaymentType PaymentType { get; set; }
        public double Money { get; set; } //số tiền
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
