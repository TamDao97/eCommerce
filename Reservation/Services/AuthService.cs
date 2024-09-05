using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Reservation.API.Commons;
using Reservation.API.DataContext.Dto;
using Reservation.API.DataContext.Entity.Extends;
using TD.Lib.Common;
using TD.Lib.Helper;

namespace Reservation.API.Services
{
    public interface IAuthService
    {
        Task<Response<CurrentUser>> LoginAsync(LoginReq req);
        Task<Response<bool>> RegisterAsync(RegisterReq req);
        Task<Response<CurrentUser>> GetCurrentUser(string userName);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;

        public AuthService(
            UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IConfiguration configuration
            , IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        public async Task<Response<CurrentUser>> GetCurrentUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null)
                return Response<CurrentUser>.Error(StatusCode.InternalServerError, "Tài khoản không tồn tại trên hệ thống!");

            var currentUser = new CurrentUser
            {
                Id = user.Id,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                IsAdmin = user.IsAdmin,
            };
            return Response<CurrentUser>.Success(currentUser, StatusCode.Ok.ToDescription());
        }

        //public async Task<Response<CurrentUser>> Login(LoginReq req)
        //{
        //    if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password))
        //        return Response<CurrentUser>.Error(StatusCode.InternalServerError, StatusCode.InternalServerError.ToDescription());

        //    var user = _unitOfWork.GetRepository<User>().AsNoTracking.SingleOrDefault(r => r.UserName == req.UserName);

        //    if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user?.PasswordHash))
        //        return Response<CurrentUser>.Error(StatusCode.InternalServerError, "Thông tin đăng nhập không chính xác!");

        //    var userProfile = _unitOfWork.GetRepository<UserProfile>().AsNoTracking.SingleOrDefault(r => r.IdUser == user.Id);

        //    var tokens = JwtHelper.GenerateToken(user.UserName, _configuration);

        //    CurrentUser currentUser = new CurrentUser
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName,
        //        DisplayName = userProfile?.DisplayName,
        //        IsAdmin = userProfile?.IsAdmin ?? false,
        //        AccessToken = tokens?.AccessToken,
        //        RefreshToken = tokens?.RefreshToken
        //    };

        //    return Response<CurrentUser>.Success(currentUser, StatusCode.Ok.ToDescription());
        //}

        //public async Task<Response<bool>> Register(RegisterReq req)
        //{
        //    string errorMess = "";
        //    if (req.Password != req.PasswordConfirm)
        //        return Response<bool>.Error(StatusCode.InternalServerError, StatusCode.InternalServerError.ToDescription());

        //    //if (IsDuplicated(ref errorMess, nameof(req.UserName), req.UserName))
        //    //    return Response<bool>.Error(StatusCode.InternalServerError, errorMess);

        //    // map model to new user object
        //    var user = new User
        //    {
        //        UserName = req.UserName,
        //        PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password)
        //    };

        //    _unitOfWork.GetRepository<User>().Insert(user);
        //    _unitOfWork.SaveChanges();

        //    return Response<bool>.Success(true, StatusCode.Ok.ToDescription());
        //}

        #region Asp core identity
        public async Task<Response<CurrentUser>> LoginAsync(LoginReq req)
        {
            var user = await _userManager.FindByNameAsync(req.UserName);

            if (user is null)
                return Response<CurrentUser>.Error(StatusCode.InternalServerError, "Tài khoản không tồn tại trên hệ thống!");

            if (!await _userManager.CheckPasswordAsync(user, req.Password))
                return Response<CurrentUser>.Error(StatusCode.InternalServerError, "Thông tin đăng nhập không chính xác!");

            var tokens = JwtHelper.GenerateToken(user.UserName, _configuration);

            CurrentUser currentUser = new CurrentUser
            {
                Id = user.Id,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                IsAdmin = user.IsAdmin,
                AccessToken = tokens.AccessToken,
                RefreshToken = tokens.RefreshToken
            };
            return Response<CurrentUser>.Success(currentUser, StatusCode.Ok.ToDescription());
        }

        public async Task<Response<bool>> RegisterAsync(RegisterReq req)
        {
            //if (IsDuplicated(ref errorMess, nameof(req.UserName), req.UserName))
            //    return Response<bool>.Error(StatusCode.InternalServerError, errorMess);

            var user = new ApplicationUser { Id = Guid.NewGuid(), UserName = req.UserName, DisplayName = req.UserName, Email = req.UserName };
            var rs = await _userManager.CreateAsync(user, req.Password);

            if (!rs.Succeeded)
                return Response<bool>.Error(StatusCode.InternalServerError, rs.Errors.FirstOrDefault()?.Description);

            await _signInManager.SignInAsync(user, isPersistent: false);
            return Response<bool>.Success(true, StatusCode.Ok.ToDescription());
        }
        #endregion
    }
}
