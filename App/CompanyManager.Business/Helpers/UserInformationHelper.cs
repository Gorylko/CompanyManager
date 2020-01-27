namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;

    public static class UserInformationHelper
    {
        public static UserInformationDto ToUserInformationDto(this UserInformation model)
        {
            return new UserInformationDto
            {
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                User = model.User?.ToUserDto(),
                UserId = model.UserId,
            };
        }

        public static UserInformation ToUserInformation(this UserInformationDto model)
        {
            return new UserInformation
            {
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                User = model.User?.ToUser(),
                UserId = model.UserId,
            };
        }
    }
}
