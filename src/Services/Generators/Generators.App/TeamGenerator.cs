

using System;
using System.Collections.Generic;
using System.Linq;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;
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

                var teamList = InitialiseTeams(match);

                //Ok shuffle the players with a utility call
                HelperMethods.Shuffle<Invite>(acceptedInvites.ToList());

                //Use boolean variable to highlight if the previous player was added to team one
                bool AddedToTeamOne = false;

                Player player = null;
                foreach (var inv in acceptedInvites)
                {
                    player = new Player()
                    {
                        Email = inv.Member.Email,
                        FirstName = inv.Member.FirstName,
                        LastName = inv.Member.LastName,
                        Rating = inv.Member.Rating
                    };

                    if (!AddedToTeamOne)
                    {
                        AddedToTeamOne = true;
                        teamList[0].Players.Add(player);
                        continue;
                    }

                    AddedToTeamOne = false;
                    teamList[1].Players.Add(player);
                    continue;
                }

                //complete - need to save these details now!
            }
        }

        protected List<Team> InitialiseTeams(Match match)
        {
            List<Team> modelList = new List<Team>();
            modelList.Add(new Team() { Number = TeamNumber.ONE, Match = match });
            modelList.Add(new Team() { Number = TeamNumber.TWO, Match = match });

            return modelList;
        }
    }
}