using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebNetCore2.Models;
using Microsoft.Extensions.Logging;
using WebNetCore2.Models2;
using Microsoft.EntityFrameworkCore;

namespace WebNetCore2.Controllers
{
    //[Produces("application/json")]
    [Route("api/Users")]
    //[Microsoft.AspNetCore.Authorization.Authorize()]
    public class UsersController : Controller
    {
        private readonly FisioDbContext _dbContext;
        private readonly ILogger _logger;

        public UsersController(FisioDbContext dbContext, ILoggerFactory logger)
        {
            _dbContext = dbContext;
            _logger = logger.CreateLogger("Controllers");
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var result = new ApiResult();

            //try
            //{
            //    result.Data = _dbContext.users.ToList();

            //    return new OkObjectResult(result);                
            //}
            //catch (Exception ex)
            //{
            //    result.Message = ex.Message;
            //    result.Severity = 0;

            //    return new BadRequestObjectResult(result);
            //}

            var result = _dbContext.Usuarios.Include(u => u.Historicologins).ToList();

            return new OkObjectResult(result);
        }

        //[HttpPut]
        //public IActionResult CheckUser([FromBody] Models.Users user)
        //{
        //    var result = new ApiResult();

        //    try
        //    {
        //        var foundUser = _dbContext.users.FirstOrDefault(u => u.googleId == user.googleId);

        //        if (foundUser == null)
        //        {

        //        }

        //        return new OkObjectResult(foundUser.userId);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;

        //        result.Severity = 0;

        //        return new BadRequestObjectResult(result);
        //    }
        //}

    }
}