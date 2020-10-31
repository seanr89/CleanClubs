using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Entities;
using Clubs.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Requests.Matches.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class UpdateMatchDetailsCommand : IRequest<bool>
    {
        public UpdateMatchDetailsDTO Match { get; set; }
    }

    public class UpdateMatchDetailsCommandHandler : IRequestHandler<UpdateMatchDetailsCommand, bool>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;
        private readonly ILogger<UpdateMatchDetailsCommandHandler> _Logger;

        public UpdateMatchDetailsCommandHandler(ClubsContext context, IMapper mapper
        , ILogger<UpdateMatchDetailsCommandHandler> logger)
        {
            _Context = context;
            _Mapper = mapper;
            _Logger = logger;
        }

        public async Task<bool> Handle(UpdateMatchDetailsCommand request, CancellationToken cancellationToken)
        {
            var existingRecord = await _Context.Matches
                .Include(m => m.Teams)
                .FirstOrDefaultAsync(m => m.Id == request.Match.Id);
            // if found we need to update then save changes!
            if (existingRecord != null)
            {
                existingRecord.Date = request.Match.Date;
                existingRecord.Location = request.Match.Location;
                existingRecord.Status = request.Match.Status;
                
                _Context.Update(existingRecord);
                return (await _Context.SaveChangesAsync()) > 0;
            }
            return false;
        }
    }
}