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
using Clubs.API.Managers.Profiles;
using Clubs.Infrastructure;
using Clubs.API.ViewModels;

namespace Clubs.API.Club.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class CreateClubCommand : IRequest<Guid>
    {
        public CreateClubViewModel Club { get; set; }
    }

    public class CreateClubCommandHandler : IRequestHandler<CreateClubCommand, Guid>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public CreateClubCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Guid> Handle(CreateClubCommand request, CancellationToken cancellationToken)
        {
            var mappedRecord = _Mapper.Map<Clubs.Domain.Entities.Club>(request.Club);
            _Context.Clubs.Add(mappedRecord);
            await _Context.SaveChangesAsync();

            return mappedRecord.Id;
        }
    }
}



