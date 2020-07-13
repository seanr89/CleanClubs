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

namespace Clubs.API.Business.Matches.Queries
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class GetMatchesForClubQuery : IRequest<IEnumerable<MatchDto>>
    {
        public Guid ClubId { get; set; }
    }

    public class GetMatchesForClubQueryHandler : IRequestHandler<GetMatchesForClubQuery, IEnumerable<MatchDto>>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetMatchesForClubQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> Handle(GetMatchesForClubQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Matches
                .Where(m => m.ClubId == request.ClubId)
                .ProjectTo<MatchDto>(_Mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
