namespace CompanyManager.Data.Models
{
    using System.Collections.Generic;

    public class EnterpriseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<EmployeeDto> Employees { get; set; }

        public virtual ICollection<PurchaseDto> Purchases { get; set; }

        public virtual ICollection<UsersToEnterprisesDto> UsersToEnterprises { get; set; }

        public virtual ICollection<WorkAreaDto> WorkAreas { get; set; }
    }
}
