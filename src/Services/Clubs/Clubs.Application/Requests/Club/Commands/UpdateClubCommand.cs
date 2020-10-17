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
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class UpdateClubCommand : IRequest<bool>
    {
        public ClubUpdateDTO Club { get; set; }
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
            var existingBlog = _Context.Clubs.Find(request.Club.Id);
            if(existingBlog != null){
                _Context.Entry(existingBlog).CurrentValues.SetValues(request.Club);
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



