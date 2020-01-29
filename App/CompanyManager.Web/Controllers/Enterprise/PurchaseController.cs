namespace CompanyManager.Web.Controllers.Enterprise
{
    using System;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/purchases")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService ?? throw new ArgumentNullException(nameof(purchaseService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid value of id");
            }

            return Ok(await _purchaseService.GetById(id));
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]int enterpriseId)
        {
            return Ok(enterpriseId < 1
                ? _purchaseService.GetAll()
                : _purchaseService.GetByEnterpriseId(enterpriseId));
        }

        [HttpPut]
        public async Task<int> Save(Purchase purchase)
        {
            return await _purchaseService.Save(purchase);
        }

        [HttpPost]
        public IActionResult Update(Purchase purchase)
        {
            _purchaseService.Update(purchase);
            return Ok("successful");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _purchaseService.Delete(id);
            return Ok("successful");
        }
    }
}