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

    public class RoleService : CommonService, IRoleService
    {
        public async Task<int> AddAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            RoleDto roleDto = role.ToRoleDto();

            using (var uow = UnitOfWork)
            {
                uow.RoleRepository.Add(roleDto);
                await uow.SaveChangesAsync();

                return roleDto.Id;
            }
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            RoleDto roleDto = null;

            using (var uow = UnitOfWork)
            {
                roleDto = await uow.RoleRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(roleDto));
            }

            return roleDto?.ToRole();
        }

        public IEnumerable<Role> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                var roles = uow.RoleRepository.GetAll();

                return roles?.Select(e => e.ToRole());
            }
        }

        public void Delete(int id)
        {
            using (var uow = UnitOfWork)
            {
                uow.RoleRepository.Delete(id);

                uow.SaveChanges();
            }
        }

        public void Delete(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            using (var uow = UnitOfWork)
            {
                uow.RoleRepository.Delete(role);

                uow.SaveChanges();
            }
        }

        public void Update(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            using (var uow = UnitOfWork)
            {
                RoleDto roleDto = uow.RoleRepository.GetById(role.Id) ?? throw new ArgumentNullException(nameof(roleDto));
                uow.RoleRepository.Update(role.ToRoleDto());

                uow.SaveChanges();
            }
        }
    }
}
