using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity
{
    public class PurchaseOrderDetail : BaseEntity
    {
        public Guid IdPurchaseOrder { get; set; }
        public Guid IdProduct { get; set; }
        public string Quantity { get; set; } //Số lượng
        public string PurchasePrice { get; set; } //Giá nhập 
        public double? PercentDiscount { get; set; } //Phần trăm giảm giá
        public double? PriceDiscount { get; set; } //Số tiền giảm giá
        public double? LastPrice { get; set; } //Số tiền sau khi chiết khấu
    }
}
