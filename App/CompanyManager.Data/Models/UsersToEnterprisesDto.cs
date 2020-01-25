namespace CompanyManager.Data.Models
{
    public class UsersToEnterprisesDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int EnterpriseId { get; set; }

        public int? RoleId { get; set; }

        public virtual EnterpriseDto Enterprise { get; set; }

        public virtual RoleDto Role { get; set; }

        public virtual UserDto User { get; set; }
    }
}