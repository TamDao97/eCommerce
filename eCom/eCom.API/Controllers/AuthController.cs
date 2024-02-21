using eCom.API.Controllers.Base;
using eCom.DataContext.Dto;
using eCom.DataContext.Entity;
using Lib.AutoMapper;
using Lib.Common;
using Lib.Repository;
using eCom.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace eCom.API.Controllers
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
            return Ok(await _authService.Register(req));
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Response<CurrentUser>>> Login(LoginReq req)
        {
            return Ok(await _authService.Login(req));
        }
    }
}