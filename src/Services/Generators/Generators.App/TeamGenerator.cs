

using System;
using System.Collections.Generic;
using System.Linq;
using Clubs.Domain.Entities;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Generators.App
{
    public class TeamGenerator
    {
        private readonly ILogger<TeamGenerator> _Logger;
        public TeamGenerator(ILogger<TeamGenerator> logger)
        {
            _Logger = logger;
        }

        public void Generate(Match match)
        {
            _Logger.LogInformation($"TeamGenerator: {HelperMethods.GetCallerMemberName()}");

            if (match.Invites.Any())
            {
                var acceptedInvites = match.Invites.Where(i => i.Accepted == true).ToList();
                //Check if the player count is even
                if (HelperMethods.IsEven(acceptedInvites.Count) == false)
                {
                    _Logger.LogInformation($"Uneven Invite count");
                }

                var teamList = InitialiseTeams();
            }
        }

        protected List<Team> InitialiseTeams()
        {
            throw new NotImplementedException();
            List<Team> ModelList = null;
            Team TeamOne = null;
            Team TeamTwo = null;
        }
    }
}