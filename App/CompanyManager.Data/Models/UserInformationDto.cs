﻿namespace CompanyManager.Data.Models
{
    public class UserInformationDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual UserDto User { get; set; }
    }
}
