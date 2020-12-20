

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Business;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Requests.Matches.Commands;
using Clubs.Application.Requests.Member.Queries;
using Clubs.Application.Services.Factories;
using Clubs.Domain.Entities;
using Clubs.Infrastructure;
using Clubs.Messages;
using Clubs.Messages.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.Application.Business
{
    /// <summary>
    /// TODO: this needs to be interfaced long term and re-named at least!
    /// </summary>
    public class MatchManager
    {
        private readonly ILogger<MatchManager> _Logger;
        protected IMediator _Mediator;
        private readonly IMapper _Mapper;
        private readonly IMessagePublisher _MessagePublisher;
        private readonly ClubsContext _DbContext;
        private readonly MatchCreationFactory _MatchCreateFactory;

        public MatchManager(ILogger<MatchManager> logger, IMediator mediator,
            IMapper mapper,
            IMessagePublisher messagePublisher,
            ClubsContext context)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _Mediator = mediator;
            _Mapper = mapper;
            _MessagePublisher = messagePublisher;
            _DbContext = context;
        }

        /// <summary>
        /// Lightweight process to handle the creation of a match and sending of invites out at a later date!
        /// </summary>
        /// <param name="match">MatchDTO: a partial match!</param>
        /// <returns>the unique of the match : or null!</returns>
        public async Task<Guid?> CreateMatch(CreateMatchDTO match)
        {
            _Logger.LogInformation($"MatchManager: {HelperMethods.GetCallerMemberName()}");
            var generator = _MatchCreateFactory.GetBaseMatchCreator();

            var mappedMatch = _Mapper.Map<Match>(match);
            //Now execute the save process!
            var newId = await this.SaveNewMatch(mappedMatch);
            return newId;
        }


        /// <summary>
        /// Support the creation of a Match Record and trigger the invitation for all club members
        /// </summary>
        /// <param name="matchView"></param>
        public async Task<Guid?> CreateMatchWithInvites(CreateInviteMatchDTO matchView)
        {
            _Logger.LogInformation($"MatchManager method: {HelperMethods.GetCallerMemberName()}");

            Guid? matchId = null;
            //TODO: remove this execution monitoring!
            using (ExecutionPerformanceMonitor monitor = new ExecutionPerformanceMonitor(_Logger, "MatchManager"))
            {
                var match = _Mapper.Map<Match>(matchView);
                //Step1. Check if invites are needed to be added/created
                if (matchView.SendInvites)
                {
                    if (!matchView.SelectedMembers.Any())
                        await GetAllMembersAndAddToInvites(match);

                    //Now we need to send the invites then!
                    await CreateInvitationRequestAndPublish(match.Invites.ToList(), matchView.Date);
                    match.InvitesSent = true;
                }
                //StepX. Save the match! (N.B. here we might want to return the object!)
                matchId = await this.SaveNewMatch(match);

                //Not awaited to speed up performance i hope!
                monitor.CreatePerformanceMetricAndLogEvent("CreateMatch");
            }
            return matchId;
        }

        #region private

        /// <summary>
        /// DB operation event to save a new match record
        /// </summary>
        /// <param name="match">match to be saved</param>
        /// <returns>a new GUID parameter to denote the match!</returns>
        private async Task<Guid?> SaveNewMatch(Match match)
        {
            _DbContext.Matches.Add(match);
            await _DbContext.SaveChangesAsync();
            return match.Id;
        }

        /// <summary>
        /// Create a new invitation request and publish to queue for a collection of invites!
        /// </summary>
        /// <param name="invites"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private async Task CreateInvitationRequestAndPublish(List<Invite> invites, DateTime date)
        {
            foreach (var inv in invites)
            {
                var contract = new InvitationRequest() { Id = inv.Id, Email = inv.Email, Date = date };
                await _MessagePublisher.Publish<InvitationRequest>(contract);
            }
        }

        /// <summary>
        /// Get all active members of a club and create an invite event!
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private async Task GetAllMembersAndAddToInvites(Match match)
        {
            var members = await _Mediator.Send(new GetClubMembersQuery() { ClubId = (Guid)match.ClubId });
            //Get only active members as no point sending to others!
            var activeMembers = members.Where(m => m.Active == true).ToList();

            //Convert members to invites!
            foreach (var a in activeMembers)
            {
                //create a new object for each invite
                var invite = new Invite(a.Email, a.Id, match.Id);
                match.Invites.Add(invite);
            }
        }

        #endregion
    }
}