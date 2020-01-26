namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;
    using System.Linq;

    public static class RoleHelper
    {
        public static RoleDto ToRoleDto(this Role model)
        {
            return new RoleDto
            {
                Id = model.Id,
                Name = model.Name,
                RolesToPermissions = model.RolesToPermissions?.Select(rtp => rtp.ToRolesToPermissionDto()).ToList(),
                UsersToEnterprises = model.UsersToEnterprises?.Select(ute => ute.ToUsersToEnterprisesDto()).ToList(),
            };
        }

        public static Role ToRole(this RoleDto model)
        {
            return new Role
            {
                Id = model.Id,
                Name = model.Name,
                RolesToPermissions = model.RolesToPermissions?.Select(rtp => rtp.ToRolesToPermission()).ToList(),
                UsersToEnterprises = model.UsersToEnterprises?.Select(ute => ute.ToUsersToEnterprises()).ToList(),
            };
        }
    }
}
