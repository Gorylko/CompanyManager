namespace CompanyManager.Web.Controllers.Enterprise
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetById(int id)
        {
            return await _employeeService.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll([FromQuery]int? enterpriseId)
        {
            return enterpriseId != null
                ? await _employeeService.GetByEnterpriseId(enterpriseId.Value)
                : await _employeeService.GetAll();
        }

        [HttpPost]
        public async Task<int> Save(Employee employee)
        {
            return await _employeeService.Save(employee);
        }

        [HttpPut("{id}")]
        public async Task Update(Employee employee, int id)
        {
            employee.Id = id;
            await _employeeService.Update(employee);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeService.Delete(id);
        }
    }
}