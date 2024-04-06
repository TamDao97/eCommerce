using eCom.DataContext.Entity.OrderSite;
using eCom.DataContext.UnitOfWork;
using eCom.Service.Base;
using Lib.Common;
using Lib.Helper;
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

        public override async Task<Response<User>> Insert(User entity)
        {
            string errorMess = "";

            if (IsDuplicated(ref errorMess, nameof(entity.UserName), entity.UserName, entity.Id))
                return Response<User>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.UserName));

            return await base.Insert(entity);
        }

        public override async Task<Response<User>> Update(User entity)
        {
            string errorMess = "";

            if (IsDuplicated(ref errorMess, nameof(entity.UserName), entity.UserName, entity.Id))
                return Response<User>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.UserName));

            return await base.Update(entity);
        }
    }
}
