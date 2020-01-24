using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyManager.Data.Models
{
    public class PermissionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolesToPermissionDto> RolesToPermissions { get; set; }
    }
}
