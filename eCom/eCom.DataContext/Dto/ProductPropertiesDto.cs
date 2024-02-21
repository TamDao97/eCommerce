using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Dto
{
    public class ProductPropertiesDto
    {
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdProperties { get; set; }
    }
}
