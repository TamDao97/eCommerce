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

        public virtual async Task<RoleDto> Insert(Role entity)
        {
            await base.Insert(entity);
            _unitOfWork.SaveChanges();
            return AutoMapperGeneric.Map<Role, RoleDto>(entity);
        }
    }
}
