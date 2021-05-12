using CustomerTemplateAPI.Exceptions;
using CustomerTemplateAPI.Models;
using CustomerTemplateAPI.Repositories.Interfaces;
using CustomerTemplateAPI.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IAuthRepository _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserRepository userService, 
                              IAuthRepository authService, 
                              UserManager<ApplicationUser> userManager, 
                              ILogger<AuthController> logger)
        {
            _userService = userService;
            _authService = authService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(JwtToken), 200)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userService.ValidateUserAsync(request.Email, request.Password);
                var securityToken = await _authService.GetJwtTokenAsync(user);

                return Ok(new JwtToken
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken),
                    ExpiredTime = securityToken.ValidTo
                });
            }
            catch (Exception ex) when (!(ex is ModelStateException))
            {
                _logger.LogWarning("Failed to login");
                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest newUser)
        {
            var user = new ApplicationUser();
            var userGuid = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                user.Id = userGuid.ToString();
                user.UserName = newUser.Username;
                user.Email = newUser.Email;
                var result = await _userManager.CreateAsync(user, newUser.Password);
            }

            return Ok(user);
        }
    }
}
