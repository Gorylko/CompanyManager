namespace CompanyManager.Web.Controllers.Enterprise
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        public PurchaseController(/*params from ioc*/)
        {
            // service initialization
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            return BadRequest();
        }

        [HttpGet("get-by-enterprise-id")]
        public IActionResult GetByEnterpriseId()
        {
            return BadRequest();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return BadRequest();
        }

        [HttpPost("save")]
        public IActionResult Save(Models.Purchase purchase)
        {
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Models.Employee purchase)
        {
            return BadRequest();
        }

        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}