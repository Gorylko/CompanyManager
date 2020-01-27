namespace CompanyManager.Web.Controllers.Enterprise
{
    using CompanyManager.Business.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEnterpriseService _enterpriseService;

        public EmployeeController(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService ?? throw new ArgumentNullException(nameof(enterpriseService));
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            return BadRequest();
        }

        [HttpGet("get-by-enterprise-id")]
        public IActionResult GetByEnterpriseId()
        {
            return BadRequest();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return BadRequest();
        }

        [HttpPost("save")]
        public IActionResult Save(Models.Employee employee)
        {
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Models.Employee employee)
        {
            return BadRequest();
        }

        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}