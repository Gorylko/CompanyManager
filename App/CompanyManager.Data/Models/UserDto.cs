using System.Collections.Generic;

namespace CompanyManager.Data.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<EnterpriseDto> Enterprises { get; set; }

        public virtual ICollection<UserInformationDto> UserInformations { get; set; }

        public virtual ICollection<UsersToEnterprisesDto> UsersToEnterprises { get; set; }
    }
}
