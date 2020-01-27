using CompanyManager.Business.Helpers.Cryptographers;
using CompanyManager.Business.Services.Interfaces;
using CompanyManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CompanyManager.Web.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly Cryptographer _cryptographer;

        public LoginController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _cryptographer = new Cryptographer();
        }

        [HttpPost("register")]
        public async Task<int> Register(UserLoginModel model)
        {
            var encrPass = _cryptographer.Encrypt(model.Password, out byte[] salt);

            return await _userService.AddAsync(new Models.User
            {
                Login = model.Email,
                Password = encrPass,
                PasswordSalt = salt,
            });
        }
    }
}