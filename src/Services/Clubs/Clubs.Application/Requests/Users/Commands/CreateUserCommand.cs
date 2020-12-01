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

namespace Clubs.Application.Requests.Club.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserDTO User { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public CreateUserCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var mappedRecord = _Mapper.Map<User>(request.User);
            _Context.Users.Add(mappedRecord);
            await _Context.SaveChangesAsync();

            return mappedRecord.Id;
        }
    }
}



