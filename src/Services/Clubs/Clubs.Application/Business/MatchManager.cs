

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Business;
using Clubs.Application.DTOs;
using Clubs.Application.Requests.Matches.Commands;
using Clubs.Application.Requests.Member.Queries;
using Clubs.Domain.Entities;
using Clubs.Messages;
using Clubs.Messages.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.Application.Business
{
    public class MatchManager
    {
        private readonly ILogger<MatchManager> _Logger;
        protected IMediator _Mediator;
        private readonly IMapper _Mapper;
        //private readonly SimpleEmailHandler _EmailHandler;
        private readonly IMessagePublisher _MessagePublisher;

        public MatchManager(ILogger<MatchManager> logger, IMediator mediator,
            IMapper mapper,
            IMessagePublisher messagePublisher)
        {
            _Logger = logger;
            _Mediator = mediator;
            _Mapper = mapper;
            //_EmailHandler = simpleEmailHandler;
            _MessagePublisher = messagePublisher;
        }

        /// <summary>
        /// TODO: lightweight process to handle the creation of a match and sending of invites out at a later date!
        /// </summary>
        /// <param name="match">MatchDTO: a partial match!</param>
        /// <returns>the unique of the match : or null!</returns>
        public async Task<Guid> CreateEmptyMatch(CreateMatchDTO match)
        {
            _Logger.LogInformation($"MatchManager: {HelperMethods.GetCallerMemberName()}");
            throw new NotImplementedException();

            Guid matchId;



            return matchId;
        }


        /// <summary>
        /// Support the creation of a Match Record and trigger the invitation for all club members
        /// </summary>
        /// <param name="matchView"></param>
        public async Task<Guid?> CreateMatch(CreateMatchDTO matchView)
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
                    foreach (var inv in match.Invites)
                    {
                        var contract = new InvitationRequest() { Id = inv.Id, Email = inv.Email, Date = matchView.Date };
                        await _MessagePublisher.Publish<InvitationRequest>(contract);
                    }
                    match.InvitesSent = true;
                }
                //StepX. Save the match! (N.B. here we might want to return the object!)
                matchId = await _Mediator.Send(new CreateMatchCommand() { Match = match });

                //Not awaited to speed up performance!
                monitor.CreatePerformanceMetricAndLogEvent("CreateMatch");
            }
            return matchId;
        }

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
    }
}