using Clubs.Domain.Entities;

namespace Clubs.Application.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Support the querying of the full user based on the current context
        /// </summary>
        /// <returns></returns>
        User GetContextUser();

        /// <summary>
        /// Supports the querying of a single user based on the provided context!
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        User GetUserFromObjectId(string objectId);
    }
}