namespace CompanyManager.Business.Services
{
    using System;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Models;

    public class RoleService : CommonService
    {
        public async Task<int> CreateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            using (var uow = UnitOfWork)
            {
                var roleDto = role.ToRoleDto();
                uow.RoleRepository.Add(roleDto);
                await uow.SaveChangesAsync();

                return roleDto.Id;
            }
        }
    }
}
