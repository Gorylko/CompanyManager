namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class UserHelper
    {
        public static UserDto ToUserDto(this User model)
        {
            return new UserDto
            {
                Id = model.Id,
            };
        }
    }
}
