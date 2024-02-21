using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity.OrderSite
{
    public class Product : BaseEntity
    {
        public Guid IdCategory { get; set; }
        public string ProductCode { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string AveragePurchasePrice { get; set; } //Giá nhập trung bình
        public string AverageSellingPriceAverage { get; set; } //Giá bán trung bình
    }
}
