namespace CompanyManager.Business.Services
{
    using System;
    using System.Threading.Tasks;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public class RoleService : CommonService
    {
        public async Task<int> CreateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var roleDto = new RoleDto
            {
                Name = role.Name,
            };

            using (var uow = UnitOfWork)
            {
                uow.RoleRepository.Add(roleDto);
                await uow.SaveChangesAsync();

                return roleDto.Id;
            }
        }
    }
}
