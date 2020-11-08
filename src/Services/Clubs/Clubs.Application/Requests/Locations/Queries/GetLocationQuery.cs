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

namespace Clubs.Application.Requests.Locations
{
    public class GetLocationQuery : IRequest<LocationDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, LocationDTO>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public GetLocationQueryHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<LocationDTO> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            return await _Context.Locations
                .ProjectTo<LocationDTO>(_Mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id);
        }
    }
}



