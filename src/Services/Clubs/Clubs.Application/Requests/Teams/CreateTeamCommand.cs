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
using Clubs.Application.Profiles.DTOs.Clubs;
using Clubs.Application.Profiles.Dto;

namespace Clubs.Application.Requests.Club.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class CreateTeamCommand : IRequest<Guid>
    {
        public CreateTeamDto Team { get; set; }
    }

    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public CreateTeamCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var mappedRecord = _Mapper.Map<Team>(request.Team);
            _Context.Teams.Add(mappedRecord);

            await _Context.SaveChangesAsync();
            return mappedRecord.Id;
        }
    }
}



