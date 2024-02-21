using eCom.DataContext.Context;
using eCom.DataContext.Entity;
using eCom.DataContext.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Config
{
    public static class ServiceRegister
    {
        public static void DataContextRegisters(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EComDbContext>(opts => opts.UseSqlServer(config["ConnectionStrings:SqlDB"]));
            services.AddScoped(typeof(IUnitOfWork), typeof(eCom.DataContext.UnitOfWork.UnitOfWork));
        }
    }
}
