namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;
    using System.Linq;

    public static class PermissionHelper
    {
        public static PermissionDto ToPermissionDto(this Permission model)
        {
            return new PermissionDto
            {
                Id = model.Id,
                Name = model.Name,
                RolesToPermissions = model.RolesToPermissions?.Select(rtp => rtp.ToRolesToPermissionDto()).ToList(),
            };
        }

        public static Permission ToPermission(this PermissionDto model)
        {
            return new Permission
            {
                Id = model.Id,
                Name = model.Name,
                RolesToPermissions = model.RolesToPermissions?.Select(rtp => rtp.ToRolesToPermission()).ToList(),
            };
        }
    }
}
