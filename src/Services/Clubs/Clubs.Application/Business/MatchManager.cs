

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
        private readonly SimpleEmailHandler _EmailHandler;
        private readonly IMessagePublisher _MessagePublisher;

        public MatchManager(ILogger<MatchManager> logger, IMediator mediator,
            IMapper mapper, SimpleEmailHandler simpleEmailHandler,
            IMessagePublisher messagePublisher)
        {
            _Logger = logger;
            _Mediator = mediator;
            _Mapper = mapper;
            _EmailHandler = simpleEmailHandler;
            _MessagePublisher = messagePublisher;
        }


        /// <summary>
        /// Support the creation of a Match Record and trigger the invitation for all club members
        /// </summary>
        /// <param name="matchView"></param>
        public async Task<Guid?> CreateMatch(CreateMatchDTO matchView)
        {
            _Logger.LogInformation($"MatchManager method: {HelperMethods.GetCallerMemberName()}");

            var match = _Mapper.Map<Match>(matchView);

            //Step1. Check if invites are needed to be added/created
            if (matchView.InviteActiveMembers)
            {
                var members = await _Mediator.Send(new GetClubMembersQuery() { ClubId = (Guid)match.ClubId });
                //Get only active members as no point sending to others
                var activeMembers = members.Where(m => m.Active == true).ToList();

                //Convert members to invites!
                List<Invite> invites = new List<Invite>();
                foreach (var a in activeMembers)
                {
                    //create a new object for each invite
                    var invite = new Invite() { Email = a.Email, MemberId = a.Id, MatchId = match.Id };
                    invites.Add(invite);
                }
                //Add invites to the match
                match.Invites = invites;
            }
            // else if (matchView.SelectedMembers.Any())
            // {
            // }

            //StepX. Save the object! (N.B. here we might want to return the object!)
            var matchId = await _Mediator.Send(new CreateMatchCommand() { Match = match });

            //StepX. Check if we need to email!
            if (matchView.SendInvites)
            {
                //Now we need to send the invites then!
                //await _EmailHandler.GenerateAndSendInviteEmails(match.Invites, match);
                //match.InvitesSent = true;
            }

            return matchId;
        }
    }
}