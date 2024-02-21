using eCom.DataContext.Entity.Base;
using eCom.DataContext.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Entity.OrderSite
{
    public class Menu : BaseEntity
    {
        public Guid IdParent { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string UrlLink { get; set; }
        public int Order { get; set; }
        public MenuType Type { get; set; }
    }
}
