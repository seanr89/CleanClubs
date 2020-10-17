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

namespace Clubs.Application.Requests.Matches.Queries
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class GetMatchesForClubQuery : IRequest<IEnumerable<MatchDTO>>
    {
        public Guid ClubId { get; set; }
    }

    public class GetMatchesForClubQueryHandler : IRequestHandler<GetMatchesForClubQuery, IEnumerable<MatchDTO>>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetMatchesForClubQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<MatchDTO>> Handle(GetMatchesForClubQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Matches
                .Where(m => m.ClubId == request.ClubId)
                .ProjectTo<MatchDTO>(_Mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
