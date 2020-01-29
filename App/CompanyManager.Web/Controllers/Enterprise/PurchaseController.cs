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
            return Ok(await _purchaseService.GetByIdAsync(id));
        }

        //[HttpGet]
        //public IActionResult GetAll([FromQuery]int enterpriseId)
        //{
        //    return Ok(enterpriseId < 1
        //        ? _purchaseService.GetAll()
        //        : _purchaseService.);
        //}

        [HttpPut]
        public async Task<IActionResult> Save(Purchase purchase)
        {
            await _purchaseService.AddAsync(purchase);
            return Ok("successful");
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