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
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Business;

namespace Clubs.Application.Requests.Club.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class RandomTeamCreateCommand : IRequest<Guid>
    {
        public CreateTeamDTO Team { get; set; }
    }

    public class RandomTeamCreateCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
    {
        private readonly GenerationService _GenerationService;
        public RandomTeamCreateCommandHandler()
        {
        }

        public async Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}



