using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace Emails.Api
{
    [ApiController]
    [Route("[controller]/action")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Running");
        }
    }
}