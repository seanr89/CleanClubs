using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        public Match Match { get; set; }
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
            var existingRecord = _Context.Matches.Find(request.Match.Id);
            if (existingRecord != null)
            {
                _Context.Entry(existingRecord).CurrentValues.SetValues(request.Match);
            }
            try
            {
                return (await _Context.SaveChangesAsync()) > 0;
            }
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.)
                _Logger.LogError($"SqlError - Unable to save changes: {ex.Message}");
                //  ModelState.AddModelError("", "Unable to save changes. " +
                //      "Try again, and if the problem persists, " +
                //      "see your system administrator.");
                return false;
            }
        }
    }
}