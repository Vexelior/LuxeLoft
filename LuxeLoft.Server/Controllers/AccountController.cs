using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLoft.Server.Controllers
{
    using BCrypt.Net;
    using LuxeLoft.Server.Data.Models.Identity;

    /// <summary>
    /// Account controller for account related operations.
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Login method.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists == null)
            {
                return BadRequest("Invalid username or password.");
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest("Invalid login attempt");
        }

        /// <summary>
        /// Register method.
        /// </summary>
        /// <param name="model"></param>
        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                LockoutEnabled = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result is not null)
            {
                return BadRequest($"A user with email '{model.Email}' already exists.");
            }

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest("Invalid register attempt");
        }

        /// <summary>
        /// Logout method.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
