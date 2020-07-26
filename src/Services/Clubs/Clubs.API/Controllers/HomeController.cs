
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clubs.API.Controllers
{

    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _Logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _Logger = logger;
        }

        [HttpGet]
        // public async Task<IActionResult> GetDBCon()
        // {

        // }
    }
}