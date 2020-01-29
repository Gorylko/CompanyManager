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
        public async Task<Enterprise> GetById(int id)
        {
            return await _enterpriseService.GetByIdAsync(id);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]int userId)
        {
            return Ok(userId < 1
                ? _enterpriseService.GetAll()
                : _enterpriseService.GetAll());
        }

        [HttpPut]
        public async Task<int> Save(Models.Enterprise enterprise)
        {
            return await _enterpriseService.AddAsync(enterprise);
        }

        [HttpPost]
        public IActionResult Update(Models.Enterprise enterprise)
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