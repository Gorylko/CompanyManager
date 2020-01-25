using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Web.Controllers.User
{
    public class UserController : Controller
    {
        public UserController(/*params from ioc*/)
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
        public IActionResult Save(Models.User employee)
        {
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Models.User employee)
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