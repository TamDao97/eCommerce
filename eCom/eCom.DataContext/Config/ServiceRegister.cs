using eCom.DataContext.Context;
using eCom.DataContext.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCom.DataContext.Config
{
    public static class ServiceRegister
    {
        public static void DataContextRegisters(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EComDbContext>(opts => opts.UseSqlServer(config["ConnectionStrings:SqlDB"]));
            services.AddIdentityCore<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<EComDbContext>();

            services.AddScoped(typeof(IUnitOfWork), typeof(eCom.DataContext.UnitOfWork.UnitOfWork));
        }
    }
}
