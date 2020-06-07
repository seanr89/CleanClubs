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

namespace Clubs.API.Club.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class UpdateClubCommand : IRequest<bool>
    {
        public ClubUpdateDto Club { get; set; }
    }

    public class UpdateClubCommandHandler : IRequestHandler<UpdateClubCommand, bool>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public UpdateClubCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<bool> Handle(UpdateClubCommand request, CancellationToken cancellationToken)
        {
            //TODO
            var mappedClub = _Mapper.Map<Clubs.Domain.Entities.Club>(request.Club);

            var existingBlog = _Context.Clubs.Find(mappedClub.Id);

            if(existingBlog != null)
            {
                mappedClub.Members = existingBlog.Members;
                mappedClub.Matches = existingBlog.Matches;
               _Context.Entry(existingBlog).CurrentValues.SetValues(mappedClub);
            }

            try
            {
                return (await _Context.SaveChangesAsync()) > 0;
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                // ModelState.AddModelError("", "Unable to save changes. " +
                //     "Try again, and if the problem persists, " +
                //     "see your system administrator.");
                return false;
            }
        }
    }
}



