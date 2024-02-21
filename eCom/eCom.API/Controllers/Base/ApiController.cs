using eCom.DataContext.Dto;
using Lib.Helper;
using eCom.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using Lib.Common;

namespace eCom.API.Controllers.Base
{
    public abstract partial class ApiController : ControllerBase
    {
        protected CurrentUser CurrentUser { get { return GetCurrentUser(); } }

        CurrentUser? GetCurrentUser()
        {
            var service = (IAuthService)HttpContext.RequestServices.GetServices(typeof(IAuthService)).SingleOrDefault();
            return service?.GetCurrentUser(HttpContext?.User?.Identity?.Name ?? string.Empty).Result;
        }
    }
}
