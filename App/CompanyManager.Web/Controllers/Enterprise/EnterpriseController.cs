namespace CompanyManager.Web.Controllers.Enterprise
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/enterprises")]
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
            return await _enterpriseService.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Enterprise>> GetAll([FromQuery]int userId)
        {
            return userId < 1
                ? await _enterpriseService.GetAll()
                : await _enterpriseService.GetAll();
        }

        [HttpPost]
        public async Task<int> Save(Enterprise enterprise)
        {
            return await _enterpriseService.Save(enterprise);
        }

        [HttpPut("{id}")]
        public async Task Update(Enterprise enterprise, int id)
        {
            enterprise.Id = id;
            await _enterpriseService.Update(enterprise);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _enterpriseService.Delete(id);
        }
    }
}