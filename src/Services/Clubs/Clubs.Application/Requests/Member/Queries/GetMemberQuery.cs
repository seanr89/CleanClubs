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

namespace Clubs.Application.Requests.Member.Queries
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class GetMemberQuery : IRequest<MemberDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetMemberQueryHandler : IRequestHandler<GetMemberQuery, MemberDTO>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetMemberQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<MemberDTO> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Members
                .AsNoTracking()
                .ProjectTo<MemberDTO>(_Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == request.Id);
        }
    }
}



