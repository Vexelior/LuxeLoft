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
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using System.Security.Claims;

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

            var currentUserId = _userManager.GetUserId(User);

            if (currentUserId != null)
            {
                return BadRequest("Another account is currently logged in.");
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, model.Email),
                    new(ClaimTypes.Email, model.Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

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
            await HttpContext.SignOutAsync();
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
