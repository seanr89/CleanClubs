using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Profiles.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Requests.Matches.Commands
{
    public class CreateMatchWithInvitesCommand: IRequest<Guid?>
    {
        public CreateMatchDTO Match { get; set; }
    }

    public class CreateMatchWithInvitesCommandHandler : IRequestHandler<CreateMatchWithInvitesCommand, Guid?>
    {
        private readonly IMapper _Mapper;
        private readonly ILogger<CreateMatchWithInvitesCommandHandler> _Logger;
        public CreateMatchWithInvitesCommandHandler(IMapper mapper,
            ILogger<CreateMatchWithInvitesCommandHandler> logger)
        {
            _Mapper = mapper;
            _Logger = logger;

        }

        public async Task<Guid?> Handle(CreateMatchWithInvitesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // _Context.Matches.Add(request.Match);
                // await _Context.SaveChangesAsync();
                // return request.Match.Id;
                return null;
            }
            catch (DbUpdateException e)
            {
                //_Logger.LogError($"SqlError - Unable to save changes: {e.Message}");
                return null;
            }
        }
    }
}