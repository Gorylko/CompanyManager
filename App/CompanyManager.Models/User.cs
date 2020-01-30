﻿using CompanyManager.Data.Models;
using System.Collections.Generic;

namespace CompanyManager.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserInformation> UserInformations { get; set; }

        public virtual ICollection<UsersToEnterprises> UsersToEnterprises { get; set; }
    }
}
