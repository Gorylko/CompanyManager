namespace CompanyManager.Business.Helpers
{
    using System.Linq;
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class UserHelper
    {
        public static UserDto ToUserDto(this User model)
        {
            return new UserDto
            {
                Id = model.Id,
                Login = model.Login,
                Password = Cryptographer.Encrypt(model.Password, out byte[] salt),
                PasswordSalt = salt,
                UserInformations = model.UserInformations?.Select(ui => ui.ToUserInformationDto()).ToList(),
                UsersToEnterprises = model.UsersToEnterprises?.Select(ute => ute.ToUsersToEnterprisesDto()).ToList(),
            };
        }

        public static User ToUser(this UserDto model)
        {
            return new User
            {
                Id = model.Id,
                Login = model.Login,
                UserInformations = model.UserInformations?.Select(ui => ui.ToUserInformation()).ToList(),
                UsersToEnterprises = model.UsersToEnterprises?.Select(ute => ute.ToUsersToEnterprises()).ToList(),
            };
        }
    }
}
