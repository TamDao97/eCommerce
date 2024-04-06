using eCom.DataContext.Dto;
using eCom.DataContext.Entity;
using eCom.DataContext.Entity.Base;
using eCom.DataContext.Entity.OrderSite;
using eCom.DataContext.UnitOfWork;
using Lib.Common;
using Lib.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Service.Base
{
    public interface IBaseService<T> where T : BaseEntity, new()
    {
        #region CRUD
        Task<Response<T>> Insert(T entity);
        Task<Response<T>> Update(T entity);
        Task<Response<T>> Delete(T entity, bool isActual = false);
        #endregion

        #region GET
        Task<Response<T>> GetById(Guid id);
        #endregion

        #region Validation logic
        public bool IsDuplicated(ref string errorMess, string fieldCheck, object valueCheck, object idValue = null);
        #endregion
    }

    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<Response<T>> Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            entity.DateCreated = DateTime.Now;
            entity.DateModify = DateTime.Now;
            entity.IsDeleted = false;

            entity = _unitOfWork.GetRepository<T>().Insert(entity);
            _unitOfWork.SaveChanges();
            return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
        }

        public virtual async Task<Response<T>> Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            entity.DateCreated = DateTime.Now;
            entity.DateModify = DateTime.Now;
            entity.IsDeleted = false;

            entity = _unitOfWork.GetRepository<T>().Update(entity);
            _unitOfWork.SaveChanges();
            return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
        }

        public virtual async Task<Response<T>> Delete(T entity, bool isActual = false)
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (!isActual)
            {
                entity.DateCreated = DateTime.Now;
                entity.DateModify = DateTime.Now;
                entity.IsDeleted = true;

                entity = _unitOfWork.GetRepository<T>().Update(entity);
                _unitOfWork.SaveChanges();
                return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
            }
            else
            {
                entity = _unitOfWork.GetRepository<T>().Delete(entity);
                _unitOfWork.SaveChanges();
                return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
            }
        }

        public virtual async Task<Response<T>> GetById(Guid id)
        {
            T entity = _unitOfWork.GetRepository<T>().GetById(id);
            if (entity == null)
                throw new ArgumentNullException();

            return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
        }

        #region Validation logic
        public bool IsDuplicated(ref string errorMess, string fieldCheck, object valueCheck, object idValue = null)
        {
            if (_unitOfWork.GetRepository<T>().AsNoTracking.AsEnumerable().Any(r => r.GetType().GetProperty("Id").GetValue(r, null).ToString() != idValue.ToString() && r.GetType().GetProperty(fieldCheck).GetValue(r, null).ToString() == valueCheck.ToString()))
            {
                errorMess = string.Format(MessageText.Duplicate, fieldCheck);
                return true;
            }
            else return false;
        }
        #endregion
    }
}
