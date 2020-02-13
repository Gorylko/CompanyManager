namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.Extensions;
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;

    public class EmployeeService : CommonService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var employeeDto = await _work.EmployeeRepository
                .Get(e => e.Id == id).GetSingleAsync();

            _work.EmployeeRepository.Delete(employeeDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await _work.EmployeeRepository.Get().GetListAsync();
            return result?.Select(e => e.ToEmployee());
        }

        public async Task<IEnumerable<Employee>> GetByEnterpriseId(int id)
        {
            return (await _work.Context.EmployeeByEnterpriseId(id).GetListAsync()).Select(e => e.ToEmployee());
        }

        public async Task<Employee> GetById(int id)
        {
            return (await _work.EmployeeRepository.Get(e => e.Id == id).GetSingleAsync()).ToEmployee();
        }

        public async Task<int> Save(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var employeeDto = employee.ToEmployeeDto();
            _work.EmployeeRepository.Add(employeeDto);
            await _work.SaveChangesAsync();
            return employeeDto.Id;
        }

        public async Task<int> Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var employeeDto = await _work.EmployeeRepository
                .Get(e => e.Id == employee.Id)
                .GetNoTracking()
                .GetSingleAsync();

            _work.EmployeeRepository.Update(employee.ToEmployeeDto());
            await _work.SaveChangesAsync();
            return employeeDto.Id;
        }
    }
}
