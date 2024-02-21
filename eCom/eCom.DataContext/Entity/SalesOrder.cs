using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity
{
    /// <summary>
    /// Phiếu xuất hàng
    /// </summary>
    public class SalesOrder : BaseEntity
    {
        public Guid IdSupplier { get; set; }
        public Guid IdUser { get; set; } //Người lập phiếu
        public string SalesOrderCode { get; set; }
        public double? PercentDiscount { get; set; } //Phần trăm giảm giá trên toàn bộ phiếu
        public double? PriceDiscount { get; set; } //Số tiền giảm giá trên toàn bộ phiếu
        public double TotalPrice { get; set; } //Tổng giá trị phiếu xuất
        public double LastPrice { get; set; } //Tổng giá trị phiếu xuất sau khi trừ chiết khấu
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
