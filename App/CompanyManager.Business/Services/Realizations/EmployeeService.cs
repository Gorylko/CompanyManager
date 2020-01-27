namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public class EmployeeService : CommonService, IEmployeeService
    {
        public async Task<int> AddAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            EmployeeDto employeeDto = employee.ToEmployeeDto();

            using (var uow = UnitOfWork)
            {
                uow.EmployeeRepository.Add(employeeDto);
                await uow.SaveChangesAsync();

                return employeeDto.Id;
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            EmployeeDto employeeDto = null;

            using (var uow = UnitOfWork)
            {
                employeeDto = await uow.EmployeeRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(employeeDto));
            }

            return employeeDto?.ToEnterprise();
        }

        public IEnumerable<Employee> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                var employees = uow.EmployeeRepository.GetAll();

                return employees?.Select(e => e.ToEnterprise());
            }
        }

        public void Delete(int id)
        {
            using (var uow = UnitOfWork)
            {
                uow.EmployeeRepository.Delete(id);

                uow.SaveChanges();
            }
        }

        public void Delete(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            using (var uow = UnitOfWork)
            {
                uow.EmployeeRepository.Delete(employee);

                uow.SaveChanges();
            }
        }

        public void Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            using (var uow = UnitOfWork)
            {
                EmployeeDto employeeDto = uow.EmployeeRepository.GetById(employee.Id) ?? throw new ArgumentNullException(nameof(employeeDto));
                uow.EmployeeRepository.Update(employee.ToEmployeeDto());

                uow.SaveChanges();
            }
        }
    }
}
