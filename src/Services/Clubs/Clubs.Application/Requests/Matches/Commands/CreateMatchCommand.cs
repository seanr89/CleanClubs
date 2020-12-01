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
using Microsoft.Extensions.Logging;
using Clubs.Application.Business;
using Clubs.Application.Profiles.DTO;

namespace Clubs.Application.Requests.Matches.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class CreateMatchCommand : IRequest<Guid?>
    {
        public CreateMatchDTO Match { get; set; }
    }

    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, Guid?>
    {
        private readonly MatchManager _MatchManager;
        private readonly ILogger<CreateMatchCommandHandler> _Logger;

        public CreateMatchCommandHandler(MatchManager manager,
            ILogger<CreateMatchCommandHandler> logger)
        {
            _MatchManager = manager;
            _Logger = logger;

        }

        public async Task<Guid?> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _MatchManager.CreateMatch(request.Match);
                return result;
            }
            catch (DbUpdateException e)
            {
                _Logger.LogError($"SqlError - Unable to save changes: {e.Message}");
                return null;
            }
        }
    }
}



