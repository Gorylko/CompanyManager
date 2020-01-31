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
        public async Task<IActionResult> GetAll([FromQuery]int userId)
        {
            return Ok(userId < 1
                ? await _enterpriseService.GetAll()
                : await _enterpriseService.GetAll());
        }

        [HttpPost]
        public async Task<int> Save(Enterprise enterprise)
        {
            Console.WriteLine("Привет");

            return await _enterpriseService.Save(enterprise);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Enterprise enterprise)
        {
            await _enterpriseService.Update(enterprise);
            return Ok("successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _enterpriseService.Delete(id);
            return Ok("successful");
        }
    }
}