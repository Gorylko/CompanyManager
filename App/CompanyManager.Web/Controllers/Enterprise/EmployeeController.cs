namespace CompanyManager.Web.Controllers.Enterprise
{
    using CompanyManager.Business.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid value of id");
            }

            return Ok(await _employeeService.GetByIdAsync(id));
        }

        [HttpGet]
        public IActionResult GetByEnterpriseId([FromQuery]int enterpriseId)
        {
            if (enterpriseId < 1)
            {
                return BadRequest("Invalid value of id");
            }

            return Ok(_employeeService.GetByEnterpriseId(enterpriseId));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpPut]
        public async Task<int> Save(Models.Employee employee)
        {
            return await _employeeService.AddAsync(employee);
        }

        [HttpPost]
        public IActionResult Update(Models.Employee employee)
        {
            _employeeService.Update(employee);
            return Ok("successful");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return Ok("successful");
        }
    }
}