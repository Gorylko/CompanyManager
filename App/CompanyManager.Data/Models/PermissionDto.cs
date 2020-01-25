namespace CompanyManager.Data.Models
{
    using System.Collections.Generic;

    public class PermissionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolesToPermissionDto> RolesToPermissions { get; set; }
    }
}
