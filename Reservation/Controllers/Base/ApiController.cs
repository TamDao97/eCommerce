using Microsoft.AspNetCore.Mvc;
using Reservation.DataContext.Dto;
using Reservation.Services;

namespace Reservation.Controllers.Base
{
    public abstract partial class ApiController : ControllerBase
    {
        protected CurrentUser CurrentUser { get { return GetCurrentUser(); } }

        CurrentUser? GetCurrentUser()
        {
            var service = (IAuthService)HttpContext.RequestServices.GetServices(typeof(IAuthService)).SingleOrDefault();
            return service?.GetCurrentUser(HttpContext?.User?.Identity?.Name ?? string.Empty).Result.Data;
        }
    }
}
