using AutoMapper;
using Clubs.Application.Services.Interfaces;
using Clubs.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Services
{
    public class SimpleMatchCreator : BaseMatchCreator, IMatchCreator
    {
        public SimpleMatchCreator(ILogger<IMatchCreator> logger, ClubsContext context, IMapper mapper) : base(logger, context, mapper)
        {
        }
    }
}