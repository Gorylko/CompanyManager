namespace CompanyManager.Web.Controllers.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInfomationService _userInfomationService;

        public UserInformationController(IUserInfomationService userInfomationService)
        {
            _userInfomationService = userInfomationService ?? throw new ArgumentNullException(nameof(userInfomationService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userInfomationService.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<UserInformation>> GetAll([FromQuery]int? userId)
        {
            return userId != null
                ? await _userInfomationService.GetAll()
                : await _userInfomationService.GetAll();
        }

        [HttpPost]
        public async Task<int> Save(UserInformation userInformation)
        {
            return await _userInfomationService.Save(userInformation);
        }

        [HttpPut("{id}")]
        public async Task Update(UserInformation userInformation, int id)
        {
            userInformation.Id = id;
            await _userInfomationService.Save(userInformation);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userInfomationService.Delete(id);
        }
    }
}