using CompanyManager.Data.Models;
using System.Collections.Generic;

namespace CompanyManager.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolesToPermission> RolesToPermissions { get; set; }
    }
}
