using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Services.Factories;
using Clubs.Domain.Entities;
using Clubs.Infrastructure;
using Utilities;

namespace Clubs.Application.Business
{
    /// <summary>
    /// TODO: this needs to be interfaced long term and re-named at least!
    /// </summary>
    public class MatchManager
    {
        private readonly ILogger<MatchManager> _Logger;
        private readonly MatchCreationFactory _MatchCreateFactory;

        public MatchManager(ILogger<MatchManager> logger,
            MatchCreationFactory factory)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _MatchCreateFactory = factory;
        }

        /// <summary>
        /// Lightweight process to handle the creation of a match and sending of invites out at a later date!
        /// </summary>
        /// <param name="match">MatchDTO: a partial match!</param>
        /// <returns>the unique id of the match : or null</returns>
        public async Task<Guid?> CreateMatch(CreateMatchDTO match)
        {
            _Logger.LogInformation($"MatchManager: {HelperMethods.GetCallerMemberName()}");
            var generator = _MatchCreateFactory.GetBaseMatchCreator();
            return await generator.Create(match);
        }


        /// <summary>
        /// Support the creation of a Match Record and trigger the invitation for all club members
        /// </summary>
        /// <param name="matchView"></param>
        /// <returns>the unique id of the match : or null</returns>
        public async Task<Guid?> CreateMatchWithInvites(CreateInviteMatchDTO matchView)
        {
            _Logger.LogInformation($"MatchManager: {HelperMethods.GetCallerMemberName()}");
            var generator = _MatchCreateFactory.GetInvitationMatchCreator();
            return await generator.Create(matchView);
        }
    }
}