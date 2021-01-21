using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Services.Interfaces;
using Clubs.Domain.Enums;
using Utilities;

namespace Clubs.Application.Business
{
    /// <summary>
    /// Base/Generic class to support random shuffling of team invites for a match
    /// </summary>
    public class TeamGenerator : ITeamGenerator
    {
        private readonly ILogger<TeamGenerator> _Logger;
        public TeamGenerator(ILogger<TeamGenerator> logger = null)
        {
            if (logger == null)
                _Logger = ApplicationLoggerProvider.CreateLogger<TeamGenerator>();
            else
                _Logger = logger;
        }

        /// <summary>
        /// Process accepted invites and create teams and attach to a match
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<MatchDTO> Generate(MatchDTO match)
        {
            _Logger.LogInformation($"TeamGenerator: {HelperMethods.GetCallerMemberName()} for {match.Id}");
            if (match.Invites.Any())
            {
                var acceptedInvites = match.Invites.Where(i => i.Accepted == true).ToList();
                //Check if the player count is even
                if (HelperMethods.IsEven(acceptedInvites.Count) == false)
                    _Logger.LogInformation($"Uneven Invite count");

                var teamList = InitialiseTeams(match);

                //Ok shuffle the players with a utility call
                HelperMethods.Shuffle<InviteDTO>(acceptedInvites.ToList());

                await ShufflePlayersIntoTeams(teamList, match, acceptedInvites);
                //complete - need to save these details now!
                match.Status = MatchStatus.Scheduled;
            }
            else
            {
                //No invitations - we may need to alert this!
                _Logger.LogWarning($"No Invites for the match: {match.Id}");
            }
            return match;
        }

        /// <summary>
        /// Supports player addition into specific teams
        /// executes a loop and 1 to 1 process!
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="match"></param>
        /// <param name="invites"></param>
        /// <returns></returns>
        async Task ShufflePlayersIntoTeams(List<TeamDTO> teams, MatchDTO match, List<InviteDTO> invites)
        {
            await Task.Run(() =>
            {
                PlayerDTO player = null;
                bool AddedToTeamOne = false;
                foreach (var inv in invites)
                {
                    player = CreatePlayerFromInvite(inv);

                    if (!AddedToTeamOne)
                    {
                        AddedToTeamOne = true;
                        teams[0].Players.Add(player);
                        continue;
                    }

                    AddedToTeamOne = false;
                    teams[1].Players.Add(player);
                }
                match.Teams = teams;
            });
        }

        /// <summary>
        /// Support the default initialisation of two teams
        /// with basic Ids and tags added!
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        protected List<TeamDTO> InitialiseTeams(MatchDTO match)
        {
            var modelList = new List<TeamDTO>();
            modelList.Add(new TeamDTO() { Number = TeamNumber.ONE, MatchId = match.Id });
            modelList.Add(new TeamDTO() { Number = TeamNumber.TWO, MatchId = match.Id });
            return modelList;
        }

        private PlayerDTO CreatePlayerFromInvite(InviteDTO inv)
        {
            return new PlayerDTO()
            {
                Email = inv.Member.Email,
                FirstName = inv.Member.FirstName,
                LastName = inv.Member.LastName,
                MemberId = inv.Member.Id
            };
        }
    }
}