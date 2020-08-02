

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clubs.Application.Profiles;
using Clubs.Application.Profiles.Dto;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.Application.Business
{
    public class TeamGenerator : ITeamGenerator
    {
        private readonly ILogger<TeamGenerator> _Logger;
        public TeamGenerator(ILogger<TeamGenerator> logger)
        {
            _Logger = logger;
        }

        public async Task<MatchDto> Generate(GenerationInfo info)
        {
            if (info.Match.Invites.Any())
            {
                var acceptedInvites = info.Match.Invites.Where(i => i.Accepted == true).ToList();
                //Check if the player count is even
                if (HelperMethods.IsEven(acceptedInvites.Count) == false)
                {
                    _Logger.LogInformation($"Uneven Invite count");
                }

                var teamList = InitialiseTeams(info.Match);

                //Ok shuffle the players with a utility call
                HelperMethods.Shuffle<InviteDto>(acceptedInvites.ToList());

                //Use boolean variable to highlight if the previous player was added to team one
                bool AddedToTeamOne = false;

                PlayerDto player = null;
                foreach (var inv in acceptedInvites)
                {
                    player = new PlayerDto()
                    {
                        Email = inv.Member.Email,
                        FirstName = inv.Member.FirstName,
                        LastName = inv.Member.LastName,
                        //Rating = inv.Member.Rating
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
                info.Match.Teams = teamList;
                //complete - need to save these details now!
            }
            return info.Match;
        }

        protected List<TeamDto> InitialiseTeams(MatchDto match)
        {
            var modelList = new List<TeamDto>();
            modelList.Add(new TeamDto() { Number = TeamNumber.ONE, MatchId = match.Id });
            modelList.Add(new TeamDto() { Number = TeamNumber.TWO, MatchId = match.Id });

            return modelList;
        }
    }
}