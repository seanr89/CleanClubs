using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clubs.Infrastructure;
using Clubs.Application.Profiles.DTOs.Clubs;

namespace Clubs.Application.Requests.Club.Queries
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class GetClubsQuery : IRequest<IEnumerable<ClubListDto>>
    {
    }

    public class GetClubsQueryHandler : IRequestHandler<GetClubsQuery, IEnumerable<ClubListDto>>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetClubsQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<ClubListDto>> Handle(GetClubsQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Clubs
                .ProjectTo<ClubListDto>(_Mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}



