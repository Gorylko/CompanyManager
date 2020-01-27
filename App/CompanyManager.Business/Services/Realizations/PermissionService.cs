namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public class PermissionService : CommonService, IPermissionService
    {
        public async Task<int> AddAsync(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            PermissionDto permissionDto = permission.ToPermissionDto();

            using (var uow = UnitOfWork)
            {
                uow.PermissionRepository.Add(permissionDto);
                await uow.SaveChangesAsync();

                return permissionDto.Id;
            }
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            PermissionDto permissionDto = null;

            using (var uow = UnitOfWork)
            {
                permissionDto = await uow.PermissionRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(permissionDto));
            }

            return permissionDto?.ToPermission();
        }

        public IEnumerable<Permission> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                var permissions = uow.PermissionRepository.GetAll();

                return permissions?.Select(e => e.ToPermission());
            }
        }

        public void Delete(int id)
        {
            using (var uow = UnitOfWork)
            {
                uow.PermissionRepository.Delete(id);

                uow.SaveChanges();
            }
        }

        public void Delete(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            using (var uow = UnitOfWork)
            {
                uow.PermissionRepository.Delete(permission);

                uow.SaveChanges();
            }
        }

        public void Update(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            using (var uow = UnitOfWork)
            {
                PermissionDto permissionDto = uow.PermissionRepository.GetById(permission.Id) ?? throw new ArgumentNullException(nameof(permissionDto));
                uow.PermissionRepository.Update(permission.ToPermissionDto());

                uow.SaveChanges();
            }
        }
    }
}
