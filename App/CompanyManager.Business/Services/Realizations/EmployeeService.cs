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
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;

    public class EmployeeService : CommonService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task<int> AddAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            EmployeeDto employeeDto = employee.ToEmployeeDto();

            _work.EmployeeRepository.Add(employeeDto);
            await _work.SaveChangesAsync();

            return employeeDto.Id;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            EmployeeDto employeeDto = null;
            employeeDto = await _work.EmployeeRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(employeeDto));

            return employeeDto?.ToEmployee();
        }

        public IQueryable<Employee> GetByEnterpriseId(int enterpriseId)
        {
            if (enterpriseId <= 0)
            {
                throw new ArgumentException("Id must be more than 0", nameof(enterpriseId));
            }

            return _work.EmployeeRepository.GetByEnterpriseId(enterpriseId).Select(employee => employee.ToEmployee());
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _work.EmployeeRepository.GetAll();

            return employees?.Select(e => e.ToEmployee());
        }

        public void Delete(int id)
        {
            _work.EmployeeRepository.Delete(id);

            _work.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _work.EmployeeRepository.Delete(employee);

            _work.SaveChanges();
        }

        public void Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            EmployeeDto employeeDto = _work.EmployeeRepository.GetById(employee.Id) ?? throw new ArgumentNullException(nameof(employeeDto));
            _work.EmployeeRepository.Update(employee.ToEmployeeDto());

            _work.SaveChanges();
        }
    }
}
