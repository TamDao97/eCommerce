using eCom.DataContext.Dto;
using Lib.Common;
using Lib.Helper;
using eCom.Service.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCom.DataContext.Entity.OrderSite;
using eCom.DataContext.UnitOfWork;

namespace eCom.Service
{
    public interface IAuthService : IBaseService<User>
    {
        Task<Response<CurrentUser>> Login(LoginReq req);
        Task<Response<bool>> Register(RegisterReq req);

        Task<CurrentUser> GetCurrentUser(string userName);
    }

    public class AuthService : BaseService<User>, IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration) : base(unitOfWork)
        {
            _configuration = configuration;
        }

        public Task<CurrentUser> GetCurrentUser(string userName)
        {
            var user = (from u in _unitOfWork.GetRepository<User>().AsNoTracking
                        where u.UserName == userName
                        join p in _unitOfWork.GetRepository<UserProfile>().AsNoTracking on u.Id equals p.IdUser into tmp
                        from t in tmp.DefaultIfEmpty()
                        select new CurrentUser
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            DisplayName = t != null ? t.DisplayName : string.Empty,
                            IsAdmin = t != null ? t.IsAdmin : false,
                        }).FirstOrDefault();

            return Task.FromResult(user);
        }

        public async Task<Response<CurrentUser>> Login(LoginReq req)
        {
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password))
                return Response<CurrentUser>.Error(StatusCode.InternalServerError, StatusCode.InternalServerError.ToDescription());

            var user = _unitOfWork.GetRepository<User>().AsNoTracking.SingleOrDefault(r => r.UserName == req.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user?.PasswordHash))
                return Response<CurrentUser>.Error(StatusCode.InternalServerError, "Thông tin đăng nhập không chính xác!");

            var userProfile = _unitOfWork.GetRepository<UserProfile>().AsNoTracking.SingleOrDefault(r => r.IdUser == user.Id);

            var tokens = JwtHelper.GenerateToken(user.UserName, _configuration);

            CurrentUser currentUser = new CurrentUser
            {
                Id = user.Id,
                UserName = user.UserName,
                DisplayName = userProfile?.DisplayName,
                IsAdmin = userProfile?.IsAdmin ?? false,
                AccessToken = tokens?.AccessToken,
                RefreshToken = tokens?.RefreshToken
            };

            return Response<CurrentUser>.Success(currentUser, StatusCode.Ok.ToDescription());
        }

        public async Task<Response<bool>> Register(RegisterReq req)
        {
            if (req.Password != req.PasswordConfirm)
                return Response<bool>.Error(StatusCode.InternalServerError, StatusCode.InternalServerError.ToDescription());

            if (_unitOfWork.GetRepository<User>().AsNoTracking.Any(r => r.UserName == req.UserName))
                return Response<bool>.Error(StatusCode.InternalServerError, StatusCode.InternalServerError.ToDescription());

            // map model to new user object
            var user = new User
            {
                UserName = req.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password)
            };

            _unitOfWork.GetRepository<User>().Insert(user);
            _unitOfWork.SaveChanges();

            return Response<bool>.Success(true, StatusCode.Ok.ToDescription());
        }
    }
}
