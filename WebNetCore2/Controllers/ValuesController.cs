using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;


namespace WebNetCore2.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Microsoft.AspNetCore.Authorization.Authorize()]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly SampleDbContext _dbContext;

        public ValuesController(SampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {

                var token = await HttpContext.GetTokenAsync("access_token");

                var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(token);
                

                var list = new List<string>();

                list.Add("1");
                list.Add("2");
                list.Add("3");
                list.Add("4");

                return list;




                // return _dbContext.locations.ToList();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
