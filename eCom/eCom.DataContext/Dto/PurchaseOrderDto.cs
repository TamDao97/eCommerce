using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Dto
{
    /// <summary>
    /// Phiếu nhập hàng
    /// </summary>
    public class PurchaseOrderDto
    {
        public Guid Id { get; set; }
        public Guid IdSupplier { get; set; }
        public Guid IdUser { get; set; } //Người lập phiếu
        public string PurchaseOrderCode { get; set; }
        public double? PercentDiscount { get; set; } //Phần trăm giảm giá trên toàn bộ phiếu
        public double? PriceDiscount { get; set; } //Số tiền giảm giá trên toàn bộ phiếu
        public double TotalPrice { get; set; } //Tổng giá trị phiếu nhập
        public double LastPrice { get; set; } //Tổng giá trị phiếu nhập sau khi trừ chiết khấu
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
