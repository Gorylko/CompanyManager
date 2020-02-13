namespace CompanyManager.Web.Controllers.Enterprise
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/workAreas")]
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
            return Ok(await _workAreaService.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<WorkArea>> GetByEnterpriseId([FromQuery]int? enterpriseId)
        {
            return enterpriseId != null
                ? await _workAreaService.GetByEnterpriseId(enterpriseId.Value)
                : await _workAreaService.GetAll();
        }

        [HttpPost]
        public async Task<int> Save(WorkArea workArea)
        {
            return await _workAreaService.Save(workArea);
        }

        [HttpPut("{id}")]
        public async Task Update(WorkArea workArea, int id)
        {
            workArea.Id = id;
            await _workAreaService.Save(workArea);
            return Ok("\"Successful\"");
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _workAreaService.Delete(id);
            return Ok("\"Successful\"");
        }
    }
}