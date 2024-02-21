using eCom.API.Controllers.Base;
using eCom.DataContext.Dto;
using eCom.DataContext.Dto.OrderSite;
using eCom.DataContext.Entity.OrderSite;
using eCom.Service;
using Lib.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<AuthController> logger
            , IUserService userService
        ) : base(userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Route("demo")]
        [HttpPost]
        public async Task<ActionResult<Response<CurrentUser>>> Demo(LoginReq req)
        {
            return Ok();
        }
    }
}
