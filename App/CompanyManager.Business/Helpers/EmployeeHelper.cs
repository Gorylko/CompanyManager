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
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                Salary = model.Salary,
            };
        }

        public static Employee ToEmployee(this EmployeeDto model)
        {
            return new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                Salary = model.Salary,
            };
        }
    }
}
