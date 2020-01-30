namespace CompanyManager.Web.Controllers.Enterprise
{
    using System;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class WorkAreaController : Controller
    {
        private readonly IWorkAreaService _workAreaService;

        public WorkAreaController(IWorkAreaService workAreaService)
        {
            _workAreaService = workAreaService ?? throw new ArgumentNullException(nameof(workAreaService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid value of id");
            }

            return Ok(await _workAreaService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetByEnterpriseId([FromQuery]int enterpriseId)
        {
            return Ok(enterpriseId < 1
                ? await _workAreaService.GetAll()
                : await _workAreaService.GetByEnterpriseId(enterpriseId));
        }

        [HttpPost]
        public async Task<int> Save(WorkArea workArea)
        {
            return await _workAreaService.Save(workArea);
        }

        [HttpPut]
        public async Task<IActionResult> Update(WorkArea workArea)
        {
            await _workAreaService.Save(workArea);
            return Ok("successful");
        }

        [HttpDelete("delete-by-id")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workAreaService.Delete(id);
            return Ok("successful");
        }
    }
}