using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using WebNetCore2.Models;
using WebNetCore2.Exceptions;

namespace WebNetCore2.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    //[Microsoft.AspNetCore.Authorization.Authorize()]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
                
        // GET api/values
        [HttpGet]
        //public async Task<IActionResult> Get()
        public IActionResult Get()
        {
            //throw new InfoException("ex");

            try
            {
                //var userId = HttpContext.User.Claims.First(c => c.Type == "user_id").Value;
                //var token = await HttpContext.GetTokenAsync("access_token");
                //var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(token);



                var list = new List<string>();

                list.Add("1");
                list.Add("2");
                list.Add("3");
                list.Add("4");
                list.Add("5");

                var result = new Models.ApiResult();
                result.Data = list;

                return new OkObjectResult(list);

                 
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("dasklsadkdksl");
                //    var result = new Result()
                //    {
                //        Sev = 0,
                //        Data = ex.ToString()
                //    };

                //    return new BadRequestObjectResult(result);
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
