

using Clubs.API.Managers.Profiles;

namespace Clubs.API.ViewModels
{
    public class CreateClubViewModel
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public bool Private { get; set; }

        public MemberDto Member { get; set; }
    }
}