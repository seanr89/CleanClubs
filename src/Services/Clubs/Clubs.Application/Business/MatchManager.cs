

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Business;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Requests.Matches.Commands;
using Clubs.Application.Requests.Member.Queries;
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

        public MatchManager(ILogger<MatchManager> logger, IMediator mediator,
            IMapper mapper,
            IMessagePublisher messagePublisher,
            ClubsContext context)
        {
            _Logger = logger;
            _Mediator = mediator;
            _Mapper = mapper;
            _MessagePublisher = messagePublisher;
            _DbContext = context;
        }

        /// <summary>
        /// TODO: lightweight process to handle the creation of a match and sending of invites out at a later date!
        /// </summary>
        /// <param name="match">MatchDTO: a partial match!</param>
        /// <returns>the unique of the match : or null!</returns>
        public async Task<Guid?> CreateMatch(CreateMatchDTO match)
        {
            _Logger.LogInformation($"MatchManager: {HelperMethods.GetCallerMemberName()}");

            var mappedMatch = _Mapper.Map<Match>(match);
            //Save the match!
            var newId = await this.SaveNewMatch(mappedMatch);
            return newId;
        }


        /// <summary>
        /// Support the creation of a Match Record and trigger the invitation for all club members
        /// </summary>
        /// <param name="matchView"></param>
        public async Task<Guid?> CreateMatchWithInvites(CreateMatchDTO matchView)
        {
            _Logger.LogInformation($"MatchManager method: {HelperMethods.GetCallerMemberName()}");

            Guid? matchId = null;
            using (ExecutionPerformanceMonitor monitor = new ExecutionPerformanceMonitor(_Logger, "MatchManager"))
            {
                var match = _Mapper.Map<Match>(matchView);
                //Step1. Check if invites are needed to be added/created
                if (matchView.InviteActiveMembers)
                {
                    await GetAllMembersAndAddToInvites(match);
                }
                //StepX. Check if we need to email and then message it!
                if (matchView.SendInvites)
                {
                    //Now we need to send the invites then!
                    await CreateInvitationRequestAndPublish(match.Invites.ToList(), matchView.Date);
                    match.InvitesSent = true;
                }
                //StepX. Save the match! (N.B. here we might want to return the object!)
                matchId = await this.SaveNewMatch(match);

                //Not awaited to speed up performance!
                monitor.CreatePerformanceMetricAndLogEvent("CreateMatch");
            }
            return matchId;
        }

        #region private

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private async Task<Guid?> SaveNewMatch(Match match)
        {
            _DbContext.Matches.Add(match);
            await _DbContext.SaveChangesAsync();
            return match.Id;
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private async Task GetAllMembersAndAddToInvites(Match match)
        {
            var members = await _Mediator.Send(new GetClubMembersQuery() { ClubId = (Guid)match.ClubId });
            //Get only active members as no point sending to others
            var activeMembers = members.Where(m => m.Active == true).ToList();

            //Convert members to invites!
            foreach (var a in activeMembers)
            {
                //create a new object for each invite
                var invite = new Invite() { Email = a.Email, MemberId = a.Id, MatchId = match.Id };
                match.Invites.Add(invite);
            }
        }

        #endregion
    }
}