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
using Clubs.API.ViewModels;

namespace Clubs.API.Club.Commands
{
    public class UpdateMemberCommand : IRequest<bool>
    {
        public MemberDto Member { get; set; }
    }

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, bool>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;

        public UpdateMemberCommandHandler(ClubsContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
             var existingRecord = _Context.Members.Find(request.Member.Id);
            if(existingRecord != null)
            {
                _Context.Entry(existingRecord).CurrentValues.SetValues(request.Member);
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



