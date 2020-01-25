namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class RoleHelper
    {
        public static RoleDto ToRoleDto(this Role model)
        {
            return new RoleDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static Role ToRole(this RoleDto model)
        {
            return new Role
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
