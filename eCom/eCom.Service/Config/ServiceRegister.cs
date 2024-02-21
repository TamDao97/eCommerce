using eCom.DataContext.Context;
using eCom.DataContext.Entity;
using eCom.Service.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Service.Config
{
    public static class ServiceRegister
    {
        public static void ServiceRegisters(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));

            //services.AddScoped(typeof(IProductService), typeof(ProductService));
            //services.AddScoped(typeof(ICategoryService), typeof(UserService));
            //services.AddScoped(typeof(ISupplierService), typeof(SupplierService));
            //services.AddScoped(typeof(IPurchaseOrderService), typeof(PurchaseOrderService));
            //services.AddScoped(typeof(ISalesOrderService), typeof(SalesOrderService));
        }
    }
}
