namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;

    public static class UsersToEnterprisesHelper
    {
        public static UsersToEnterprisesDto ToUsersToEnterprisesDto(this UsersToEnterprises model)
        {
            return new UsersToEnterprisesDto
            {
                UserId = model.UserId,
                Enterprise = model.Enterprise?.ToEnterpriseDto(),
                EnterpriseId = model.EnterpriseId,
                Id = model.Id,
                Role = model.Role?.ToRoleDto(),
                RoleId = model.RoleId,
                User = model.User?.ToUserDto(),
            };
        }

        public static UsersToEnterprises ToUsersToEnterprises(this UsersToEnterprisesDto model)
        {
            return new UsersToEnterprises
            {
                UserId = model.UserId,
                Enterprise = model.Enterprise?.ToEnterprise(),
                EnterpriseId = model.EnterpriseId,
                Id = model.Id,
                Role = model.Role?.ToRole(),
                RoleId = model.RoleId,
                User = model.User?.ToUser(),
            };
        }
    }
}
