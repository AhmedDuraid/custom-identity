using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        private readonly string _connectionString;
        public Test(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        // GET: api/<Test>
        [HttpGet]
        public void Get()
        {
            using (var connection = new SqlConnection(_connectionString))
            {


                var list = connection.Query($@"select * from Users;");


            }
            var d = new { };


        }

        // GET api/<Test>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Test>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Test>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Test>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
