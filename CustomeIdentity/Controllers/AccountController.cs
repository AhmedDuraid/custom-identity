using CustomeIdentity.CoustomProvider;
using CustomeIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomeIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }


        // POST: /Account/Register
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");

                }
                else
                {
                    return NotFound(result);
                }

            }

            // If we got this far, something failed, redisplay form
            return Ok();

        }

        [HttpGet]
        public IEnumerable<string> Get(string name)
        {

            var result = _userManager.FindByNameAsync(name).Result.Id.ToString();

            return new string[] { "value1", result };
        }
    }
}
