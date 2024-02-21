using eCom.DataContext.Entity.Base;
using eCom.DataContext.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity.OrderSite
{
    public class Image : BaseEntity
    {
        public Guid IdObject { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Base64String { get; set; }
        public ImageType Type { get; set; }
    }
}
