using CompanyManager.Models;

namespace CompanyManager.Data.Models
{
    public class UsersToEnterprises
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int EnterpriseId { get; set; }

        public int? RoleId { get; set; }

        public virtual Enterprise Enterprise { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}