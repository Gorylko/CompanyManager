namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class EmployeeHelper
    {
        public static EmployeeDto ToEmployeeDto(this Employee model)
        {
            return new EmployeeDto
            {
                Id = model.Id,
                Enterprise = model.Enterprise?.ToEnterpriseDto(),
                EnterpriseId = model.EnterpriseId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                Salary = model.Salary,
            };
        }

        public static Employee ToEnterprise(this EmployeeDto model)
        {
            return new Employee
            {
                Id = model.Id,
                Enterprise = model.Enterprise?.ToEnterprise(),
                EnterpriseId = model.EnterpriseId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                Salary = model.Salary,
            };
        }
    }
}
