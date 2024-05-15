using eCom.DataContext.Entity;
using eCom.DataContext.Entity.OrderSite;
using eCom.DataContext.UnitOfWork;
using eCom.Service.Base;
using Lib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Service
{
    public interface ICustomerService : IBaseService<Customer>
    {
    }

    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<Response<Customer>> Insert(Customer entity)
        {
            string errorMess = "";

            if (IsDuplicated(ref errorMess, nameof(entity.CustomerCode), entity.CustomerCode, entity.Id))
                return Response<Customer>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.CustomerCode));

            if (IsDuplicated(ref errorMess, nameof(entity.Phone), entity.Phone, entity.Id))
                return Response<Customer>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.CustomerCode));

            return await base.Insert(entity);
        }

        public override async Task<Response<Customer>> Update(Customer entity)
        {
            string errorMess = "";

            if (IsDuplicated(ref errorMess, nameof(entity.CustomerCode), entity.CustomerCode, entity.Id))
                return Response<Customer>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.CustomerCode));

            if (IsDuplicated(ref errorMess, nameof(entity.Phone), entity.Phone, entity.Id))
                return Response<Customer>.Error(StatusCode.InternalServerError, String.Format(MessageText.Duplicate, entity.CustomerCode));

            return await base.Update(entity);
        }


    }
}
