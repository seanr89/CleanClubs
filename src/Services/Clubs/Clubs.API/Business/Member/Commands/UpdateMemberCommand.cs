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
using Microsoft.Extensions.Logging;

namespace Clubs.API.Club.Commands
{
    //https://dotnetcoretutorials.com/2019/04/30/the-mediator-pattern-part-3-mediatr-library/
    //https://medium.com/@ducmeit/net-core-using-cqrs-pattern-with-mediatr-part-1-55557e90931b
    public class UpdateMemberCommand : IRequest<bool>
    {
        public MemberDto Member { get; set; }
    }

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, bool>
    {
        private readonly ClubsContext _Context;
        private readonly IMapper _Mapper;
        private readonly ILogger _Logger;

        public UpdateMemberCommandHandler(ClubsContext context, IMapper mapper, ILogger logger)
        {
            _Context = context;
            _Mapper = mapper;
            _Logger = logger;
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
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.)
                _Logger.LogError($"SqlError - Unable to save changes: {ex.Message}");
                // ModelState.AddModelError("", "Unable to save changes. " +
                //     "Try again, and if the problem persists, " +
                //     "see your system administrator.");
                return false;
            }
        }
    }
}



