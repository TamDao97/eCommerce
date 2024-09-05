using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reservation.API.Commons;
using Reservation.API.DataContext;
using Reservation.API.DataContext.Entity.Extends;
using Reservation.API.Services;
using Reservation.API.UnitOfWork;
using System.Text;

namespace Reservation.API.Configs
{
    public static class ServiceRegister
    {
        // Add services to the container.
        public static void DataContextRegisters(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ReservationDbContext>(opts => opts.UseSqlServer(config["ConnectionStrings:ReservationDbContextConnection"]));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<ReservationDbContext>()
                    .AddDefaultTokenProviders()
                    .AddErrorDescriber<CustomIdentityErrorDescriber>(); // Đăng ký CustomIdentityErrorDescriber;

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.SignIn.RequireConfirmedEmail = false;
            });

            // Configure Authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // on production make it true
                    ValidateAudience = false, // on production make it true
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ClockSkew = TimeSpan.Zero
                };
                o.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void DependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
        }

        public static void Configs(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettings>(config.GetSection("AppSettings"));
        }
    }
}
