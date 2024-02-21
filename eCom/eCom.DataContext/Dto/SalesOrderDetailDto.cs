using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Dto
{
    public class SalesOrderDetailDto
    {
        public Guid Id { get; set; }
        public Guid IdSalesOrder { get; set; }
        public Guid IdProduct { get; set; }
        public string Quantity { get; set; } //Số lượng
        public string SalePrice { get; set; } //Giá xuất 
        public double? PercentDiscount { get; set; } //Phần trăm giảm giá
        public double? PriceDiscount { get; set; } //Số tiền giảm giá
        public double? LastPrice { get; set; } //Số tiền sau khi chiết khấu
    }
}
