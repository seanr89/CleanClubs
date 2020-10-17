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

    public class UpdateMatchCommand : IRequest<bool>
    {
        public MatchDTO Match { get; set; }
    }

    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand, bool>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;
        private readonly ILogger<UpdateMatchCommandHandler> _Logger;

        public UpdateMatchCommandHandler(ClubsContext context, IMapper mapper
        , ILogger<UpdateMatchCommandHandler> logger)
        {
            _Context = context;
            _Mapper = mapper;
            _Logger = logger;
        }

        public async Task<bool> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            var convertedMatch = _Mapper.Map<Match>(request.Match);
            var existingRecord = await _Context.Matches
                .Include(m => m.Teams)
                .FirstOrDefaultAsync(m => m.Id == convertedMatch.Id);
            // if found we need to update then save changes!
            if (existingRecord != null)
            {
                _Context.Entry(existingRecord).CurrentValues.SetValues(convertedMatch);
                existingRecord.Teams = convertedMatch.Teams;
                _Context.Update(existingRecord);

                _Context.Teams.AddRange(existingRecord.Teams);

                return (await _Context.SaveChangesAsync()) > 0;
            }
            return false;
        }
    }
}