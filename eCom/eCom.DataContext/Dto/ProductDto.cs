using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid IdCategory { get; set; }
        public string ProductCode { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string PurchasePrice { get; set; } //Giá nhập 
        public string SellingPrice { get; set; } //Giá bán
        public string DateExpired { get; set; }
        public string Properties { get; set; }
    }
}
