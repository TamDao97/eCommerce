using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity
{
    /// <summary>
    /// Phiếu nhập/xuất kho
    /// </summary>
    public class InventoryReceipt : BaseEntity
    {
        public Guid IdPurchaseOrder { get; set; } //Hóa đơn mua hàng
        public Guid IdSalesOrder { get; set; } //Hóa đơn bán hàng
        public Guid IdUser { get; set; } //Người lập phiếu
        public string InventoryReceiptCode { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
