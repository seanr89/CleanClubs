

using Clubs.API.Managers.Profiles;

namespace Clubs.API.Business.Clubs.Commands
{
    public class CreateClubDTO
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public bool Private { get; set; }
    }
}