using eCom.DataContext.Entity.OrderSite;
using eCom.DataContext.UnitOfWork;
using eCom.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Service
{
    public interface IUserService : IBaseService<User>
    {
    }

    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
