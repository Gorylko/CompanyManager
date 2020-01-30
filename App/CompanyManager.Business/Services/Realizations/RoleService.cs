namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;
    using Microsoft.EntityFrameworkCore;

    public class RoleService : CommonService, IRoleService
    {
        public RoleService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var roleDto = await _work.RoleRepository
                .Get(e => e.Id == id).SingleAsync();

            _work.RoleRepository.Delete(roleDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var result = await _work.RoleRepository.Get().ToListAsync();
            return result?.Select(e => e.ToRole());
        }

        public async Task<Role> GetById(int id)
        {
            return (await _work.RoleRepository.Get(e => e.Id == id).SingleAsync()).ToRole();
        }

        public async Task<int> Save(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var roleDto = role.ToRoleDto();
            _work.RoleRepository.Add(roleDto);
            await _work.SaveChangesAsync();
            return roleDto.Id;
        }

        public async Task<int> Update(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var roleDto = await _work.RoleRepository
                .Get(e => e.Id == role.Id)
                .AsNoTracking()
                .SingleAsync();

            _work.RoleRepository.Update(role.ToRoleDto());
            await _work.SaveChangesAsync();
            return roleDto.Id;
        }

        //public async Task<int> AddAsync(Role role)
        //{
        //    if (role == null)
        //    {
        //        throw new ArgumentNullException(nameof(role));
        //    }

        //    RoleDto roleDto = role.ToRoleDto();

        //    _work.RoleRepository.Add(roleDto);
        //    await _work.SaveChangesAsync();

        //    return roleDto.Id;

        //}

        //public async Task<Role> GetByIdAsync(int id)
        //{
        //    RoleDto roleDto = null;

        //    roleDto = await _work.RoleRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(roleDto));

        //    return roleDto?.ToRole();
        //}

        //public IEnumerable<Role> GetAll()
        //{
        //    var roles = _work.RoleRepository.GetAll();

        //    return roles?.Select(e => e.ToRole());
        //}

        //public void Delete(int id)
        //{
        //    _work.RoleRepository.Delete(id);

        //    _work.SaveChanges();
        //}

        //public void Delete(Role role)
        //{
        //    if (role == null)
        //    {
        //        throw new ArgumentNullException(nameof(role));
        //    }

        //    _work.RoleRepository.Delete(role);

        //    _work.SaveChanges();
        //}

        //public void Update(Role role)
        //{
        //    if (role == null)
        //    {
        //        throw new ArgumentNullException(nameof(role));
        //    }

        //    RoleDto roleDto = _work.RoleRepository
        //                           .Get(r => r.Id == role.Id)
        //                           .AsNoTracking()
        //                           .FirstOrDefault() ?? throw new ArgumentNullException(nameof(roleDto));

        //    _work.RoleRepository.Update(role.ToRoleDto());

        //    _work.SaveChanges();
        //}
    }
}
