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
using Clubs.API.Managers.Profiles.Dto;

namespace Clubs.API.Club.Queries
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class GetMatchesQuery : IRequest<IEnumerable<MatchDto>>
    {
    }

    public class GetMatchesQueryHandler : IRequestHandler<GetMatchesQuery, IEnumerable<MatchDto>>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetMatchesQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Matches
                .ProjectTo<MatchDto>(_Mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}



