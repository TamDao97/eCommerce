using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Dto
{
    public class ProductHistoryDto
    {
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string PurchasePrice { get; set; } //Giá nhập 
        public string SellingPrice { get; set; } //Giá bán
        public string DateExpired { get; set; }
    }
}
