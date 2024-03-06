using eCom.DataContext.Entity.Base;
using eCom.Service.Base;
using Lib.AutoMapper;
using Lib.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCom.API.Controllers.Base
{
    public class BaseController<TEntity, TDto> : ApiController where TEntity : BaseEntity, new() where TDto : class
    {
        private readonly IBaseService<TEntity> _baseService;

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [Route("insert")]
        [HttpPost]
        public async Task<ActionResult<Response<bool>>> Insert(TDto dtoReq)
        {
            TEntity entity = AutoMapperGeneric.Map<TDto, TEntity>(dtoReq);
            return Ok(await _baseService.Insert(entity));
        }

        [Route("update")]
        [HttpPost]
        public async Task<ActionResult<Response<bool>>> Update(TDto dtoReq)
        {
            TEntity entity = AutoMapperGeneric.Map<TDto, TEntity>(dtoReq);
            return Ok(await _baseService.Update(entity));
        }

        [Route("delete/{id}")]
        [HttpPost]
        public async Task<ActionResult<Response<bool>>> Delete(Guid id)
        {
            TEntity entity = await _baseService.GetById(id);
            return Ok(await _baseService.Delete(entity));
        }

        [Route("getbyid/{id}")]
        [HttpPost]
        public async Task<ActionResult<Response<bool>>> GetById(Guid id)
        {
            return Ok(await _baseService.GetById(id));
        }
    }
}
