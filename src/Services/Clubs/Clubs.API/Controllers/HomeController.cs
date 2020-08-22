
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Clubs.API.Controllers
{
    //[Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        // private readonly IConfiguration _Configuration;
        // private readonly ILogger<HomeController> _Logger;
        // private readonly IWebHostEnvironment _HostingEnv;
        public HomeController()
        {
            //_Logger = logger;
            // _Configuration = configuration;
            // _HostingEnv = hostingEnvironment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }

        // [HttpGet]
        // public IActionResult GetDBCon()
        // {
        //     return Ok(_Configuration.GetValue<string>("ConnectionSettings:Default"));
        // }

        // [HttpGet]
        // public IActionResult GetEnv()
        // {
        //     return Ok(_HostingEnv.EnvironmentName);
        // }
    }
}