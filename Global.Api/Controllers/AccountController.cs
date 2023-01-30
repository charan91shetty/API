using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global.Domain.Model;
using Global.Domain.Repository;
using Global.Domain.Repository.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Global.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignupAsnc(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded +":Account Created");
            }

            return Unauthorized();
        }

        [HttpGet("SignIn")]
        public async Task<IActionResult> LogIn([FromBody] SignInModel signInModel)
        {
            var token = await _accountRepository.LogInAsync(signInModel);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        // Todo -CurrentUser API logic
        [HttpGet("CurrentUser/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser([FromRoute] string userId)
        {
           //Todo- write logic to get current user

            return Ok(new CurrentUserDetailsModel());
        }


        [HttpGet]
        [Authorize]
        [Route("SubscriptionDetails/{userId}")]
        public async Task<IActionResult> GetSubscriptionDetails([FromRoute] string userId)
        {
            var token = await _accountRepository.LogInAsync(new SignInModel());
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }


        [HttpGet("SignOut")]
        public async Task<IActionResult> Logout([FromBody] SignUpModel signOutModel)
        {
            var status = await _accountRepository.LogOutAsync(signOutModel);
           

            return Ok(status);
        }
    }
}
