using Lib.AutoMapper;
using eCom.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCom.DataContext.Entity.OrderSite;
using eCom.DataContext.Dto;
using eCom.DataContext.UnitOfWork;
using Lib.Common;

namespace eCom.Service
{
    public interface IRoleService : IBaseService<Role>
    {

    }

    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<Response<Role>> Insert(Role entity)
        {
            string errorMess = "";

            if (IsDuplicated(ref errorMess, nameof(entity.Code), entity.Code, entity.Id))
                return Response<Role>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.Code));

            return await base.Insert(entity);
        }

        public override async Task<Response<Role>> Update(Role entity)
        {
            string errorMess = "";

            if (IsDuplicated(ref errorMess, nameof(entity.Code), entity.Code, entity.Id))
                return Response<Role>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.Code));

            return await base.Update(entity);
        }
    }
}
