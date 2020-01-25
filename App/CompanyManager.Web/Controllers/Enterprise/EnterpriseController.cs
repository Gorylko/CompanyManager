namespace CompanyManager.Web.Controllers.Enterprise
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class EnterpriseController : Controller
    {
        public EnterpriseController(/*params from ioc*/)
        {
            // service initialization
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return View();
        }

        [HttpPost("save")]
        public IActionResult Save(Models.Enterprise enterprise)
        {
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Models.Enterprise enterprise)
        {
            return BadRequest();
        }

        [HttpPost("delete-by-id")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}