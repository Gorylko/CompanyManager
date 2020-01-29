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
        public IActionResult GetByEnterpriseId([FromQuery]int enterpriseId)
        {
            return Ok(enterpriseId < 1
                ? _workAreaService.GetAll()
                : _workAreaService.GetByEnterpriseId(enterpriseId));
        }

        [HttpPut]
        public async Task<int> Save(WorkArea workArea)
        {
            return await _workAreaService.Save(workArea);
        }

        [HttpPost]
        public IActionResult Update(WorkArea workArea)
        {
            _workAreaService.Save(workArea);
            return Ok("successful");
        }

        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            _workAreaService.Delete(id);
            return Ok("successful");
        }
    }
}