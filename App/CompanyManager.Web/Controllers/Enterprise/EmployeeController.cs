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

            return Ok(await _employeeService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int enterpriseId)
        {
            return Json(enterpriseId < 1
                ? await _employeeService.GetAll()
                : await _employeeService.GetByEnterpriseId(enterpriseId));
        }

        [HttpPut]
        public async Task<int> Save(Models.Employee employee)
        {
            return await _employeeService.Save(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Models.Employee employee)
        {
            await _employeeService.Update(employee);
            return Ok("successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return Ok("successful");
        }
    }
}