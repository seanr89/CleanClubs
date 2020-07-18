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

namespace Clubs.Application.Requests.Matches.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class CreateMatchCommand : IRequest<Guid>
    {
        public Match Match { get; set; }
    }

    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, Guid>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public CreateMatchCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Guid> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            _Context.Matches.Add(request.Match);
            await _Context.SaveChangesAsync();

            return request.Match.Id;
        }
    }
}



