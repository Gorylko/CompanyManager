namespace CompanyManager.Web.Controllers.Enterprise
{
    using System;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/enterprises")]
    public class EnterpriseController : Controller
    {
        private readonly IEnterpriseService _enterpriseService;

        public EnterpriseController(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService ?? throw new ArgumentNullException(nameof(enterpriseService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid value of id");
            }

            return Ok(await _enterpriseService.GetById(id));
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]int userId)
        {
            return Ok(userId < 1
                ? _enterpriseService.GetAll()
                : _enterpriseService.GetAll());
        }

        [HttpPut]
        public async Task<int> Save(Enterprise enterprise)
        {
            return await _enterpriseService.Save(enterprise);
        }

        [HttpPost]
        public IActionResult Update(Enterprise enterprise)
        {
            _enterpriseService.Update(enterprise);
            return Ok("successful");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _enterpriseService.Delete(id);
            return Ok("successful");
        }
    }
}