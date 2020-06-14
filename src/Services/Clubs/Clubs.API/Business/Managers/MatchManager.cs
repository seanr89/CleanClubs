

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.API.Club.Commands;
using Clubs.API.Club.Queries;
using Clubs.API.ViewModels;
using Clubs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.API.Business.Managers
{
    public class MatchManager
    {
        private readonly ILogger<MatchManager> _Logger;
        protected IMediator _Mediator;
        private readonly IMapper _Mapper;

        public MatchManager(ILogger<MatchManager> logger, IMediator mediator, IMapper mapper)
        {
            _Logger = logger;
            _Mediator = mediator;
            _Mapper = mapper;
        }

        
        /// <summary>
        /// Support the creation of a Match Record and trigger the invitation for all club members
        /// </summary>
        /// <param name="matchView"></param>
        public async Task<Guid> CreateMatch(CreateMatchViewModel matchView)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");

            var match = _Mapper.Map<Match>(matchView);

            //Step1. Check if invites are needed to be added/created
            if(matchView.InviteActiveMembers)
            {
                var members = await _Mediator.Send(new GetClubMembersQuery() {ClubId = (Guid)match.ClubId}); 

                //TODO: get only active members!
                var activeMembers = members.Where(m => m.Active == true).ToList();

                //TODO: convert members to invites!
                List<Invite> invites = new List<Invite>();
                foreach(var a in activeMembers)
                {
                    invites.Add(_Mapper.Map<Invite>(a));
                }
                //TODO: add invites to the object! (N.B. we may need to convert the object before here with the mapping!)
                match.Invites = invites;
            }

            //StepX. Save the object! (N.B. here we might want to return the object!)
            var matchId = await _Mediator.Send(new CreateMatchCommand() {Match = match});

            //StepX. Check if we need to email!
            if(matchView.SendInvites)
            {
                //TODO: we need to send the invites then!
            }
            
            return matchId;
        }
    }
}