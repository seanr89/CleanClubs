

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Enums;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.Application.Business
{
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
        /// Supports the default random shuffle fo players into teams
        /// </summary>
        /// <param name="info"></param>
        /// <returns>Returns the MatchDTO with teams!</returns>
        /*
        public async Task<MatchDTO> Generate(GenerationInfo info)
        {
            _Logger.LogInformation($"TeamGenerator: {HelperMethods.GetCallerMemberName()} for {info.Match.Id}");
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
                HelperMethods.Shuffle<InviteDTO>(acceptedInvites.ToList());

                await ShufflePlayersIntoTeams(teamList, info.Match, acceptedInvites);
                //complete - need to save these details now!
                info.Match.Status = MatchStatus.Scheduled;
            }
            return info.Match;
        }*/

        async Task ShufflePlayersIntoTeams(List<TeamDTO> teams, MatchDTO match, List<InviteDTO> invites)
        {
            await Task.Run(() =>
            {
                PlayerDTO player = null;
                bool AddedToTeamOne = false;
                foreach (var inv in invites)
                {
                    player = new PlayerDTO()
                    {
                        Email = inv.Member.Email,
                        FirstName = inv.Member.FirstName,
                        LastName = inv.Member.LastName,
                        MemberId = inv.Member.Id
                    };

                    if (!AddedToTeamOne)
                    {
                        AddedToTeamOne = true;
                        teams[0].Players.Add(player);
                        continue;
                    }

                    AddedToTeamOne = false;
                    teams[1].Players.Add(player);
                    continue;
                }
                match.Teams = teams;
            });
        }

        /// <summary>
        /// Support the default initialisation of two teams
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
                {
                    _Logger.LogInformation($"Uneven Invite count");
                }

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
            }
            return match;
        }
    }
}