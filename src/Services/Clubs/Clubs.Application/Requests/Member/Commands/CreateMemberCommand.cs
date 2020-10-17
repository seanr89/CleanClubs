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

namespace Clubs.Application.Requests.Member.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class CreateMemberCommand : IRequest<Guid>
    {
        public CreateMemberDTO Member { get; set; }
    }

    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Guid>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public CreateMemberCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var mappedRecord = _Mapper.Map<Clubs.Domain.Entities.Member>(request.Member);
            _Context.Members.Add(mappedRecord);
            await _Context.SaveChangesAsync();

            return mappedRecord.Id;
        }
    }
}



