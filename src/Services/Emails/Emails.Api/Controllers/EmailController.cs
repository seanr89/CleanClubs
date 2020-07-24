
using System;
using System.Threading.Tasks;
using Emails.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Emails.API.Controllers
{
    [ApiController]
    public class EmailController : ApiController
    {
        private readonly ILogger<EmailController> _Logger;
        public EmailController(ILogger<EmailController> logger)
        {
            _Logger = logger;
        }

        public async Task<IActionResult> Post(string email)
        {
            throw new NotImplementedException();
        }
    }
}