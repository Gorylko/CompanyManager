namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.Extensions;
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;

    public class PermissionService : CommonService, IPermissionService
    {
        public PermissionService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var permissionDto = await _work.PermissionRepository
                .Get(e => e.Id == id).GetSingleAsync();

            _work.PermissionRepository.Delete(permissionDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            var result = await _work.PermissionRepository.Get().GetListAsync();
            return result?.Select(e => e.ToPermission());
        }

        public async Task<Permission> GetById(int id)
        {
            return (await _work.PermissionRepository.Get(e => e.Id == id).GetSingleAsync()).ToPermission();
        }

        public async Task<int> Save(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            var permissionDto = permission.ToPermissionDto();
            _work.PermissionRepository.Add(permissionDto);
            await _work.SaveChangesAsync();
            return permissionDto.Id;
        }

        public async Task<int> Update(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            var permissionDto = await _work.PermissionRepository
                .Get(e => e.Id == permission.Id)
                .GetNoTracking()
                .GetSingleAsync();

            _work.PermissionRepository.Update(permission.ToPermissionDto());
            await _work.SaveChangesAsync();
            return permissionDto.Id;
        }
    }
}
