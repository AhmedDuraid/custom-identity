using CustomIdentity.CoustomProvider;
using CustomIdentity.Models;
using IdentityHelper.Library.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CustomIdentity.Controllers
{
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserRoleDataAccess _userRoleDataAccess;
        private readonly string _connectionString;

        public TokenController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _userRoleDataAccess = new UserRoleDataAccess();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            //_connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        [HttpGet]
        [Route("/token")]
        public void Get()
        {

        }

        [Route("/token")]
        [HttpPost]
        public async Task<IActionResult> Create(string username, string password, string grant_type)
        {
            if (await IsValidUsernameAndPassword(username, password))
            {
                return new ObjectResult(await GenerateToken(username));
            }
            else
            {
                return BadRequest();
            }

        }

        private async Task<bool> IsValidUsernameAndPassword(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);

            return await _userManager.CheckPasswordAsync(user, password);


        }

        // create new token
        private async Task<dynamic> GenerateToken(string username)
        {
            // get user information 
            var user = await _userManager.FindByEmailAsync(username);

            // get all this user roles to be added to the claim

            var roles = _userRoleDataAccess.LoadUserRoleByID<UserRoleModel, dynamic>
                  (_connectionString, new { @UserId = user.Id }, "dbo.spUserRole_GetUserRoleById");

            var claims = new List<Claim> {

                new Claim(ClaimTypes.Name,username ),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
               new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            // adding user roles to the claim 
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));

            }

            // create new token
            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKeysecretKeysecretKeysecretKey")),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = username
            };

            return output;
        }
    }
}
