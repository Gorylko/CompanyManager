namespace CompanyManager.Web.Controllers.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("{id}")]
        public async Task<User> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpPost]
        public async Task<int> Save(User user)
        {
            return await _userService.Save(user);
        }

        [HttpPut("{id}")]
        public async Task Update(User user, int id)
        {
            user.Id = id;
            await _userService.Update(user);
            return Ok("\"Successful\"");
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.Delete(id);
            return Ok("\"Successful\"");
        }
    }
}