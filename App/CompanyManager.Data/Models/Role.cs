namespace CompanyManager.Data.Models
{
    using System.Collections.Generic;

    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolesToPermissionDto> RolesToPermissions { get; set; }

        public virtual ICollection<UsersToEnterprisesDto> UsersToEnterprises { get; set; }
    }
}
