using System;
using System.Threading.Tasks;
using AuthDemo.Domain.Entities.Identity;
using AuthDemo.Identity.Jwt.Interfaces;
using AuthDemo.Web.Controllers;
using AuthDemo.Web.Features.Authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Web.Features.Authorization
{
    [Route("[controller]")]
    public class AuthorizeController : ApiControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthorizeController(IJwtTokenGenerator jwtTokenGenerator, SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCredentials model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
            if (result.IsLockedOut || !result.Succeeded)
                return Unauthorized();

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return Unauthorized();

            var userRoles = await _userManager.GetRolesAsync(user);
            var tokenResult = _jwtTokenGenerator.Generate(user, userRoles);

            HttpContext.Response.Cookies.Append(
                ".AspNetCore.Application.Id",
                tokenResult.AccessToken,
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(60) });

            return Ok(tokenResult.Expires);
        }
    }
}
