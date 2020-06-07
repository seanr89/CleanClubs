

using System;
using Clubs.API.Managers.Profiles;

namespace Clubs.API.ViewModels
{
    public class ClubsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public bool Private { get; set; }
        public string Creator { get; set; }
    }
}