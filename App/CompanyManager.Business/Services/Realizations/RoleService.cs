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

    public class RoleService : CommonService, IRoleService
    {
        public RoleService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var roleDto = await _work.RoleRepository
                .Get(e => e.Id == id).GetSingleAsync();

            _work.RoleRepository.Delete(roleDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var result = await _work.RoleRepository.Get().GetListAsync();
            return result?.Select(e => e.ToRole());
        }

        public async Task<Role> GetById(int id)
        {
            return (await _work.RoleRepository.Get(e => e.Id == id).GetSingleAsync()).ToRole();
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
                .GetNoTracking()
                .GetSingleAsync();

            _work.RoleRepository.Update(role.ToRoleDto());
            await _work.SaveChangesAsync();
            return roleDto.Id;
        }
    }
}
