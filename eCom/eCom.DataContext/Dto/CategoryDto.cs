using eCom.DataContext.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public Guid IdParent { get; set; }
        public string CategoryCode { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
