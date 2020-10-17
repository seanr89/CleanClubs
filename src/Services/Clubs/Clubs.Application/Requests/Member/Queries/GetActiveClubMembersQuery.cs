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

    public class GetActiveClubMembersQuery : IRequest<IEnumerable<MemberDTO>>
    {
        public Guid ClubId { get; set; }
    }

    public class GetActiveClubMembersQueryHandler : IRequestHandler<GetActiveClubMembersQuery, IEnumerable<MemberDTO>>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetActiveClubMembersQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<MemberDTO>> Handle(GetActiveClubMembersQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Members
                .Where(m => m.ClubId == request.ClubId && m.Active == true)
                .AsNoTracking()
                .ProjectTo<MemberDTO>(_Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}



