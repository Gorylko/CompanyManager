namespace CompanyManager.Data.Models
{
    public class RolesToPermissionDto
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public virtual PermissionDto Permission { get; set; }

        public virtual RoleDto Role { get; set; }
    }
}
