
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Clubs.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private readonly ILogger<HomeController> _Logger;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _Logger = logger;
            _Configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetDBCon()
        {
            return Ok(_Configuration.GetValue<string>("ConnectionSettings:Default"));
        }
    }
}