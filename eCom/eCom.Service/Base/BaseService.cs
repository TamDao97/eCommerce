using eCom.DataContext.Entity;
using eCom.DataContext.Entity.Base;
using eCom.DataContext.UnitOfWork;
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
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity, bool isActual = false);
        #endregion

        #region GET
        Task<T> GetById(Guid id);
        #endregion

        #region Validation logic
        bool IsDuplicated(string field, ref string errorMess);
        #endregion
    }

    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<T> Insert(T entity)
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
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            entity.DateCreated = DateTime.Now;
            entity.DateModify = DateTime.Now;
            entity.IsDeleted = false;

            entity = _unitOfWork.GetRepository<T>().Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public virtual async Task<T> Delete(T entity, bool isActual = false)
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
                return entity;
            }
            else
            {
                entity = _unitOfWork.GetRepository<T>().Delete(entity);
                _unitOfWork.SaveChanges();
                return entity;
            }
        }

        public virtual async Task<T> GetById(Guid id)
        {
            T entity = _unitOfWork.GetRepository<T>().GetById(id);
            if (entity == null)
                throw new ArgumentNullException();

            return entity;
        }

        #region Validation logic
        public bool IsDuplicated(string fieldCheck, ref string errorMess)
        {
            if (_unitOfWork.GetRepository<T>().AsNoTracking.Any(r => r.GetType().GetProperty(fieldCheck).GetValue(r, null)) ==)
            {

            };
        }
        #endregion
    }
}
