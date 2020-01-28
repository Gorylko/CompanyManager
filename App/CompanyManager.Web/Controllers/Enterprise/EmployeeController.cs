namespace CompanyManager.Web.Controllers.Enterprise
{
    using CompanyManager.Business.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            return BadRequest();
        }

        [HttpGet("get-by-enterprise-id")]
        public IActionResult GetByEnterpriseId(int id)
        {
            return Ok(_employeeService.GetByEnterpriseId(id));
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpPost("save")]
        public async Task<int> Save(Models.Employee employee)
        {
            return await _employeeService.AddAsync(employee);
        }

        [HttpPost("update")]
        public IActionResult Update(Models.Employee employee)
        {
            return BadRequest();
        }

        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return Ok();
        }
    }
}