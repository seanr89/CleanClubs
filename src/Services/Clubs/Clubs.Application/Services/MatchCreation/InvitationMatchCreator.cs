using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Requests.Member.Queries;
using Clubs.Application.Services.Interfaces;
using Clubs.Domain.Entities;
using Clubs.Infrastructure;
using Clubs.Messages;
using Clubs.Messages.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Services
{
    public class InvitationMatchCreator : BaseMatchCreator, IMatchCreator
    {
        private readonly IMessagePublisher _MessagePublisher;
        protected IMediator _Mediator;

        public InvitationMatchCreator(ILogger<IMatchCreator> logger, ClubsContext context, IMapper mapper) : base(logger, context, mapper)
        {
        }

        /// <summary>
        /// Supports creation with invites also being handled
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public override async Task<Guid?> Create(object match)
        {
            Guid? matchId = null;
            CreateInviteMatchDTO castMatch = (CreateInviteMatchDTO)match;
            var mappedMapped = this._Mapper.Map<Match>(match);
            //Step1. Check if invites are needed to be added/created
            if (castMatch.SendInvites == true)
            {
                if (!castMatch.SelectedMembers.Any())
                    await GetAllMembersAndAddToInvites(mappedMapped);

                //Now we need to send the invites then!
                await CreateInvitationRequestAndPublish(mappedMapped.Invites.ToList(), castMatch.Date);
                mappedMapped.InvitesSent = true;
            }
            //StepX. Save the match! (N.B. here we might want to return the object!)
            matchId = await this.SaveNewMatch(mappedMapped);

            return matchId;
        }

        #region Private Methods

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