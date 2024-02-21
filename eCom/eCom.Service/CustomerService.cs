using eCom.DataContext.Entity;
using eCom.DataContext.UnitOfWork;
using eCom.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Service
{
    public interface ICustomerService : IBaseService<Customer>
    {
    }

    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
