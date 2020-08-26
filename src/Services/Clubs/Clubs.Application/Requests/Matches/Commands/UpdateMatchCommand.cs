using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Profiles.Dto;
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
        public MatchDto Match { get; set; }
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
            var existingRecord = _Context.Matches.Find(convertedMatch.Id);
            if (existingRecord != null)
            {
                _Context.Entry(existingRecord).CurrentValues.SetValues(convertedMatch);
            }
            try
            {
                return (await _Context.SaveChangesAsync()) > 0;
            }
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.)
                _Logger.LogError($"Match Update SqlError - Unable to save changes: {ex.Message}");
                //  ModelState.AddModelError("", "Unable to save changes. " +
                //      "Try again, and if the problem persists, " +
                //      "see your system administrator.");
                return false;
            }
        }
    }
}