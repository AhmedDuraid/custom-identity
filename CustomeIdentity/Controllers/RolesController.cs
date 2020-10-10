using CustomIdentity.CoustomProvider;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;

        }
        // GET: api/<RolesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        public async Task<IActionResult> AddNewRole([FromBody] ApplicationRole roleInfo)
        {
            var role = new ApplicationRole { Name = roleInfo.Name };

            IdentityResult result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }




    }
}
