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

namespace Clubs.Application.Requests.Users.Queries
{
    public class GetUserByObjectQuery : IRequest<UserDTO>
    {
        public string ObjectId { get; set; }
    }

    public class GetUserByObjectQueryHandler : IRequestHandler<GetUserByObjectQuery, UserDTO>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetUserByObjectQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByObjectQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Users
                .ProjectTo<UserDTO>(_Mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ObjectId == request.ObjectId);
        }
    }
}



