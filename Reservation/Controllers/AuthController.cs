using Base.Lib.Common;
using Microsoft.AspNetCore.Mvc;
using Reservation.Controllers.Base;
using Reservation.DataContext.Dto;
using Reservation.Services;
namespace Reservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ApiController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<Response<bool>>> Register(RegisterReq req)
        {
            return Ok(await _authService.RegisterAsync(req));
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Response<CurrentUser>>> Login(LoginReq req)
        {
            return Ok(await _authService.LoginAsync(req));
        }
    }
}