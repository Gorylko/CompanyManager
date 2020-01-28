using CompanyManager.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyManager.Web.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<int> Save(Models.User user)
        {
            return await _userService.AddAsync(user);
        }

        [HttpPost("update")]
        public IActionResult Update(Models.User user)
        {
            _userService.Update(user);
            return BadRequest();
        }

        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}