using CompanyManager.Data.Models;

namespace CompanyManager.Business.Helpers
{
    public static class RolesToPermissionHelper
    {
        public static RolesToPermissionDto ToRolesToPermissionDto(this RolesToPermission model)
        {
            return new RolesToPermissionDto
            {
                Id = model.Id,
                Permission = model.Permission?.ToPermissionDto(),
                PermissionId = model.PermissionId,
                Role = model.Role?.ToRoleDto(),
                RoleId = model.RoleId,
            };
        }

        public static RolesToPermission ToRolesToPermission(this RolesToPermissionDto model)
        {
            return new RolesToPermission
            {
                Id = model.Id,
                Permission = model.Permission?.ToPermission(),
                PermissionId = model.PermissionId,
                Role = model.Role?.ToRole(),
                RoleId = model.RoleId,
            };
        }
    }
}
