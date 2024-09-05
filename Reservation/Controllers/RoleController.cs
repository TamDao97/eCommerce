using Microsoft.AspNetCore.Mvc;
using Reservation.API.Attributes;
using Reservation.API.Controllers.Base;
using Reservation.API.DataContext.Dto.Extends;
using Reservation.API.Services;
using TD.Lib.Common;

namespace Reservation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TDModule("Quản lý quyền", 1)]
    public class RoleController : ApiController
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        [TDPermission("CreateAsync", "This is a role create", "LE_TAN")]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Response<ApplicationRoleDto>>> CreateAsync(ApplicationRoleDto reqDto)
        {
            return Ok(await _roleService.CreateAsync(reqDto));
        }

        [Route("update")]
        [HttpPost]
        public async Task<ActionResult<Response<ApplicationRoleDto>>> UpdateAsync(ApplicationRoleDto reqDto)
        {
            return Ok(await _roleService.UpdateAsync(reqDto));
        }

        [Route("delete/{id}")]
        [HttpPost]
        public async Task<ActionResult<Response<bool>>> DeleteAsync(Guid id)
        {
            return Ok(await _roleService.DeleteAsync(id));
        }

        [Route("getbyid/{id}")]
        [HttpGet]
        public async Task<ActionResult<Response<ApplicationRoleDto>>> GetByIdAsync(Guid id)
        {
            return Ok(await _roleService.GetByIdAsync(id));
        }

        [Route("scan-permission")]
        [HttpGet]
        public async Task<ActionResult<Response<ApplicationRoleDto>>> ScanPermissionAsync()
        {
            return Ok(await _roleService.ScanPermissionAsync());
        }
    }
}