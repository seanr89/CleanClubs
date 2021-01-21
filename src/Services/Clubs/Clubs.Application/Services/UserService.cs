using Clubs.Application.Services.Interfaces;
using Clubs.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }
        
        public User GetContextUser()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserFromObjectId(string objectId)
        {
            throw new System.NotImplementedException();
        }
    }
}