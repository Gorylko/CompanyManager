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
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;
    using Microsoft.EntityFrameworkCore;

    public class PermissionService : CommonService, IPermissionService
    {
        public PermissionService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(Permission model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Permission model)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> AddAsync(Permission permission)
        //{
        //    if (permission == null)
        //    {
        //        throw new ArgumentNullException(nameof(permission));
        //    }

        //    PermissionDto permissionDto = permission.ToPermissionDto();

        //    _work.PermissionRepository.Add(permissionDto);
        //    await _work.SaveChangesAsync();

        //    return permissionDto.Id;
        //}

        //public async Task<Permission> GetByIdAsync(int id)
        //{
        //    PermissionDto permissionDto = null;

        //    permissionDto = await _work.PermissionRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(permissionDto));

        //    return permissionDto?.ToPermission();
        //}

        //public IEnumerable<Permission> GetAll()
        //{
        //    var permissions = _work.PermissionRepository.GetAll();

        //    return permissions?.Select(e => e.ToPermission());
        //}

        //public void Delete(int id)
        //{
        //    _work.PermissionRepository.Delete(id);

        //    _work.SaveChanges();
        //}

        //public void Delete(Permission permission)
        //{
        //    if (permission == null)
        //    {
        //        throw new ArgumentNullException(nameof(permission));
        //    }

        //    _work.PermissionRepository.Delete(permission);

        //    _work.SaveChanges();

        //}

        //public void Update(Permission permission)
        //{
        //    if (permission == null)
        //    {
        //        throw new ArgumentNullException(nameof(permission));
        //    }

        //    PermissionDto permissionDto = _work.PermissionRepository
        //                                       .Get(p => p.Id == permission.Id)
        //                                       .AsNoTracking()
        //                                       .FirstOrDefault() ?? throw new ArgumentNullException(nameof(permissionDto));

        //    _work.PermissionRepository.Update(permission.ToPermissionDto());

        //    _work.SaveChanges();
        //}
    }
}
