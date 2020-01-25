namespace CompanyManager.Web.Controllers.Enterprise
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class WorkAreaController : Controller
    {
        public WorkAreaController(/*params from ioc*/)
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
            return View();
        }

        [HttpPost("save")]
        public IActionResult Save(Models.WorkArea workArea)
        {
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Models.WorkArea workArea)
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