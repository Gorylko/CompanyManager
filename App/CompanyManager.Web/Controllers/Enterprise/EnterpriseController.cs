namespace CompanyManager.Web.Controllers.Enterprise
{
    using CompanyManager.Business.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class EnterpriseController : Controller
    {
        private readonly IEnterpriseService _enterpriseService;

        public EnterpriseController(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            return BadRequest();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return BadRequest();
        }

        [HttpPost("save")]
        public async Task<int> Save(Models.Enterprise enterprise)
        {
            return await _enterpriseService.AddAsync(enterprise);
        }

        [HttpPost("update")]
        public IActionResult Update(Models.Enterprise enterprise)
        {
            _enterpriseService.Update(enterprise);
            return BadRequest();
        }

        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            _enterpriseService.Delete(id);
            return BadRequest();
        }
    }
}