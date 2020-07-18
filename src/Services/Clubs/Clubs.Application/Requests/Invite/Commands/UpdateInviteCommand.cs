using Clubs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clubs.Infrastructure;
using Clubs.Application.Profiles;

namespace Clubs.Application.Requests.Invite.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class UpdateInviteCommand : IRequest<bool>
    {
        public InviteDto Invite { get; set; }
    }

    public class UpdateInviteCommandHandler : IRequestHandler<UpdateInviteCommand, bool>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public UpdateInviteCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<bool> Handle(UpdateInviteCommand request, CancellationToken cancellationToken)
        {
            var invitation = await _Context.Invites.FirstOrDefaultAsync(i => i.Id == request.Invite.Id);

            if(invitation != null)
            {
                invitation.Accepted = request.Invite.Accepted;
                invitation.Date = DateTime.UtcNow;
                await _Context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}



