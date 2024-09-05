using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Reservation.API.Attributes;
using Reservation.API.Commons;
using Reservation.API.DataContext.Dto.Extends;
using Reservation.API.DataContext.Entity;
using Reservation.API.DataContext.Entity.Extends;
using Reservation.API.UnitOfWork;
using System.Reflection;
using TD.Lib.AutoMapper;
using TD.Lib.Common;
using TD.Lib.Helper;

namespace Reservation.API.Services
{
    public interface IRoleService
    {
        #region CRUD
        Task<Response<ApplicationRoleDto>> CreateAsync(ApplicationRoleDto reqDto);
        Task<Response<ApplicationRoleDto>> UpdateAsync(ApplicationRoleDto reqDto);
        Task<Response<bool>> DeleteAsync(Guid id);
        #endregion

        #region GET
        Task<Response<ApplicationRoleDto>> GetByIdAsync(Guid id);
        Task<Response<PagingData<List<ApplicationRoleDto>>>> GetByFilterAsync(RoleGridFilter gridDto);
        #endregion

        #region FEATURE
        Task<Response<bool>> ScanPermissionAsync();
        #endregion
    }

    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;

        #region repos
        private readonly TD.Lib.Repository.IRepository<ApplicationRole> _roleRepos;
        private readonly TD.Lib.Repository.IRepository<Permission> _permissionRepos;
        private readonly TD.Lib.Repository.IRepository<RolePermission> _rolePermissionRepos;
        #endregion

        public RoleService(
            IUnitOfWork unitOfWork
            , IConfiguration configuration
            , IOptions<AppSettings> appSettings)
        {
            _roleRepos = unitOfWork.GetRepository<ApplicationRole>();
            _permissionRepos = unitOfWork.GetRepository<Permission>();
            _rolePermissionRepos = unitOfWork.GetRepository<RolePermission>();
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        public async Task<Response<ApplicationRoleDto>> CreateAsync(ApplicationRoleDto reqDto)
        {
            if (_roleRepos.AsNoTracking.Any(r => r.Id != reqDto.Id && r.NormalizedName == reqDto.NormalizedName))
            {
                return Response<ApplicationRoleDto>.Error(StatusCode.InternalServerError, ErrorMess.Duplicated(reqDto.NormalizedName));
            }

            ApplicationRole entity = AutoMapperGeneric.Map<ApplicationRoleDto, ApplicationRole>(reqDto);

            entity.DateCreated = DateTime.Now;
            entity.DateModify = DateTime.Now;
            entity.IsDeleted = false;

            await _roleRepos.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            ApplicationRoleDto dto = AutoMapperGeneric.Map<ApplicationRole, ApplicationRoleDto>(entity);
            return Response<ApplicationRoleDto>.Success(dto, StatusCode.Ok.ToDescription());
        }

        public async Task<Response<bool>> DeleteAsync(Guid id)
        {
            var entity = await _roleRepos.GetByIdAsync(id);

            if (entity == null)
            {
                return Response<bool>.Error(StatusCode.NotFound, StatusCode.NotFound.ToDescription());
            }

            entity.IsDeleted = true;

            await _roleRepos.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Response<bool>.Success(true, StatusCode.Ok.ToDescription());
        }

        public async Task<Response<PagingData<List<ApplicationRoleDto>>>> GetByFilterAsync(RoleGridFilter gridDto)
        {
            var query = _roleRepos.AsNoTracking;

            if (!string.IsNullOrEmpty(gridDto.Keyword))
            {
                query = query.Where(r => r.Code.Trim().ToLower().Contains(gridDto.Keyword.Trim().ToLower())
                              || r.Code.Trim().ToLower().Contains(gridDto.Keyword.Trim().ToLower()));
            }

            int totalItems = query.Select(r => r.Id).Count();
            var lstItemsPagging = query.Skip(gridDto.PageNumber - 1 * gridDto.PageSize)
                                        .Take(gridDto.PageSize)
                                        .Select(r => AutoMapperGeneric.Map<ApplicationRole, ApplicationRoleDto>(r))
                                        .ToList();

            var item = PagingData<List<ApplicationRoleDto>>.Create(lstItemsPagging, gridDto.PageNumber, totalItems / gridDto.PageSize, totalItems);
            return Response<PagingData<List<ApplicationRoleDto>>>.Success(item, StatusCode.Ok.ToDescription());
        }

        public async Task<Response<ApplicationRoleDto>> GetByIdAsync(Guid id)
        {
            var item = await _roleRepos.GetByIdAsync(id);

            if (item == null)
                return Response<ApplicationRoleDto>.Error(StatusCode.InternalServerError, StatusCode.InternalServerError.ToDescription());

            ApplicationRoleDto dto = AutoMapperGeneric.Map<ApplicationRole, ApplicationRoleDto>(item);
            return Response<ApplicationRoleDto>.Success(dto, StatusCode.Ok.ToDescription());
        }

        public async Task<Response<ApplicationRoleDto>> UpdateAsync(ApplicationRoleDto reqDto)
        {
            //ApplicationRole entity = AutoMapperGeneric.Map<ApplicationRoleDto, ApplicationRole>(reqDto);

            var entity = await _roleRepos.GetByIdAsync(reqDto.Id);

            if (entity == null)
            {
                return Response<ApplicationRoleDto>.Error(StatusCode.NotFound, StatusCode.NotFound.ToDescription());
            }

            entity.Code = reqDto.Code;
            entity.Name = reqDto.Name;
            entity.NormalizedName = reqDto.NormalizedName;
            entity.Description = reqDto.Description;
            entity.DateModify = DateTime.Now;

            var rs = await _roleRepos.UpdateAsync(entity);

            ApplicationRoleDto dto = AutoMapperGeneric.Map<ApplicationRole, ApplicationRoleDto>(entity);
            return Response<ApplicationRoleDto>.Success(dto, StatusCode.Ok.ToDescription());
        }

        public async Task<Response<bool>> ScanPermissionAsync()
        {
            //Get db
            var lstRolesDb = _roleRepos.AsNoTracking.ToList();

            // Lấy tất cả các loại (types) trong assembly hiện tại
            var assembly = Assembly.GetExecutingAssembly();
            var controllerTypes = assembly.GetTypes()
                                          .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && !t.IsAbstract)
                                          .ToList();

            var lstPermissionAdd = new List<Permission>();
            var lstRolePermissionAdd = new List<RolePermission>();

            Permission permission = null;
            foreach (var controller in controllerTypes)
            {
                Console.WriteLine($"Controller: {controller.Name}");

                // Lấy các attributes của controller
                var moduleAttribute = controller.GetCustomAttributes(true).FirstOrDefault(r => r.GetType().Name == nameof(TDModuleAttribute)) as TDModuleAttribute;

                if (moduleAttribute is null) continue;

                Console.WriteLine($"  [Module Attribute] {moduleAttribute.GetType().Name}");

                // Lấy các methods trong controller
                var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                foreach (var method in methods)
                {
                    Console.WriteLine($"Method: {method.Name}");

                    // Lấy các attributes của method
                    var methodAttribute = method.GetCustomAttributes(true).FirstOrDefault(r => r.GetType().Name == nameof(TDPermissionAttribute)) as TDPermissionAttribute;

                    Console.WriteLine($"[Method Attribute] {methodAttribute.GetType().Name}");

                    permission = new Permission
                    {
                        Id = Guid.NewGuid(),
                        ModuleCode = controller.Name,
                        ModuleDescription = moduleAttribute.Description,
                        ModuleOrder = moduleAttribute.Order,
                        PermissionCode = methodAttribute.PermissionCode,
                        Description = methodAttribute.Description
                    };
                    lstPermissionAdd.Add(permission);

                    var lstRoleCode = methodAttribute.RoleCodes?.Split(",", StringSplitOptions.RemoveEmptyEntries);

                    ApplicationRole role = null;
                    foreach (var roleCode in lstRoleCode)
                    {
                        role = lstRolesDb.FirstOrDefault(r => r.Code == roleCode);

                        if (role is null) continue;

                        RolePermission rolePermission = new RolePermission
                        {
                            IdRole = role.Id,
                            IdPermission = permission.Id
                        };
                        lstRolePermissionAdd.Add(rolePermission);
                    }
                }
            }

            _permissionRepos.CreateAsync();
            _rolePermissionRepos.CreateAsync();
            return default;
        }
    }
}
