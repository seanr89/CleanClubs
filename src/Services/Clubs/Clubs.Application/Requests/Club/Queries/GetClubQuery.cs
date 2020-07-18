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

namespace Clubs.API.Club.Queries
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class GetClubQuery : IRequest<ClubDto>
    {
        public Guid Id { get; set; }
    }

    public class GetClubQueryHandler : IRequestHandler<GetClubQuery, ClubDto>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetClubQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<ClubDto> Handle(GetClubQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Clubs
                .Include(c => c.Members)
                .ProjectTo<ClubDto>(_Mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id);
        }
    }
}



