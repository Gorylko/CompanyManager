namespace CompanyManager.Web.Controllers.Enterprise
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/purchases")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService ?? throw new ArgumentNullException(nameof(purchaseService));
        }

        [HttpGet("{id}")]
        public async Task<Purchase> GetById(int id)
        {
            return await _purchaseService.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Purchase>> GetAll([FromQuery]int? enterpriseId)
        {
            return enterpriseId != null
                ? await _purchaseService.GetByEnterpriseId(enterpriseId.Value)
                : await _purchaseService.GetAll();
        }

        [HttpPost]
        public async Task<int> Save(Purchase purchase)
        {
            return await _purchaseService.Save(purchase);
        }

        [HttpPut("{id}")]
        public async Task Update(Purchase purchase, int id)
        {
            purchase.Id = id;
            await _purchaseService.Update(purchase);
            return Ok("\"Successful\"");
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _purchaseService.Delete(id);
            return Ok("\"Successful\"");
        }
    }
}