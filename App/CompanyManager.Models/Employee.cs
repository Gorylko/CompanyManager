namespace CompanyManager.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public virtual Enterprise Enterprise { get; set; }
    }
}
