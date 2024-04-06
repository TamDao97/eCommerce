using eCom.API.Controllers.Base;
using eCom.DataContext.Dto;
using eCom.DataContext.Dto.OrderSite;
using eCom.DataContext.Entity.OrderSite;
using eCom.Service;
using Lib.Common;
using Microsoft.AspNetCore.Mvc;

namespace eCom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<Role, RoleDto>
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(
            ILogger<RoleController> logger
            , IRoleService roleService
        ) : base(roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        public override Task<ActionResult<Response<bool>>> Insert(RoleDto dtoReq)
        {
            return base.Insert(dtoReq);
        }

        public override Task<ActionResult<Response<bool>>> Update(RoleDto dtoReq)
        {
            return base.Update(dtoReq);
        }
    }
}
