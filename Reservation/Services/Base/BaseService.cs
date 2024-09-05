using Reservation.API.DataContext.Entity.Base;
using Reservation.API.UnitOfWork;
using TD.Lib.Common;
using TD.Lib.Helper;

namespace Reservation.API.Services.Base
{
    public interface IBaseService<T> where T : BaseEntity, new()
    {
        #region CRUD
        Task<Response<T>> CreateAsync(T entity);
        Task<Response<T>> UpdateAsync(T entity);
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

        public virtual async Task<Response<T>> CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            entity.DateCreated = DateTime.Now;
            entity.DateModify = DateTime.Now;
            entity.IsDeleted = false;

            entity = await _unitOfWork.GetRepository<T>().CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
        }

        public virtual async Task<Response<T>> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            entity.DateCreated = DateTime.Now;
            entity.DateModify = DateTime.Now;
            entity.IsDeleted = false;

            entity = await _unitOfWork.GetRepository<T>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
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

                entity = await _unitOfWork.GetRepository<T>().UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
            }
            else
            {
                entity = await _unitOfWork.GetRepository<T>().DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return Response<T>.Success(entity, StatusCode.Ok.ToDescription());
            }
        }

        public virtual async Task<Response<T>> GetById(Guid id)
        {
            T entity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
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
