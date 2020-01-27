﻿using CompanyManager.Data.Models;
using System.Collections.Generic;

namespace CompanyManager.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolesToPermission> RolesToPermissions { get; set; }

        public virtual ICollection<UsersToEnterprises> UsersToEnterprises { get; set; }
    }
}
