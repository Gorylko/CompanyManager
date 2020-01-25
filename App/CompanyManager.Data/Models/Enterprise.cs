namespace CompanyManager.Data.Models
{
    using System.Collections.Generic;

    public class Enterprise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public virtual ICollection<UsersToEnterprisesDto> UsersToEnterprises { get; set; }

        public virtual ICollection<WorkArea> WorkAreas { get; set; }
    }
}
