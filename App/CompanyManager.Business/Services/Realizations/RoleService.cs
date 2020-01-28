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

    public class RoleService : CommonService, IRoleService
    {
        public RoleService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task<int> AddAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            RoleDto roleDto = role.ToRoleDto();

            _work.RoleRepository.Add(roleDto);
            await _work.SaveChangesAsync();

            return roleDto.Id;

        }

        public async Task<Role> GetByIdAsync(int id)
        {
            RoleDto roleDto = null;

            roleDto = await _work.RoleRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(roleDto));

            return roleDto?.ToRole();
        }

        public IEnumerable<Role> GetAll()
        {
            var roles = _work.RoleRepository.GetAll();

            return roles?.Select(e => e.ToRole());
        }

        public void Delete(int id)
        {
            _work.RoleRepository.Delete(id);

            _work.SaveChanges();
        }

        public void Delete(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            _work.RoleRepository.Delete(role);

            _work.SaveChanges();
        }

        public void Update(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            RoleDto roleDto = _work.RoleRepository.GetById(role.Id) ?? throw new ArgumentNullException(nameof(roleDto));
            _work.RoleRepository.Update(role.ToRoleDto());

            _work.SaveChanges();
        }
    }
}
