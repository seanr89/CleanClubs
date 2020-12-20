using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Business;
using Clubs.Application.Profiles.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Requests.Matches.Commands
{
    public class CreateMatchWithInvitesCommand : IRequest<Guid?>
    {
        public CreateInviteMatchDTO Match { get; set; }
    }

    public class CreateMatchWithInvitesCommandHandler : IRequestHandler<CreateMatchWithInvitesCommand, Guid?>
    {
        private readonly MatchManager _MatchManager;
        private readonly ILogger<CreateMatchWithInvitesCommandHandler> _Logger;
        public CreateMatchWithInvitesCommandHandler(MatchManager manager,
            ILogger<CreateMatchWithInvitesCommandHandler> logger)
        {
            _MatchManager = manager;
            _Logger = logger;

        }

        public async Task<Guid?> Handle(CreateMatchWithInvitesCommand request, CancellationToken cancellationToken)
        {
            var result = await _MatchManager.CreateMatchWithInvites(request.Match);
            return result;
        }
    }
}