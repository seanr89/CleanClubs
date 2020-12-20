using System;
using System.Threading.Tasks;
using Clubs.Application.Requests.Matches.Commands;
using Clubs.Application.Requests.Matches.Queries;
using Clubs.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.Application.Business
{
    public class GenerationService
    {
        private readonly ILogger<GenerationService> _logger;
        private readonly IMediator _mediator;
        public GenerationService(ILogger<GenerationService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteTeamGenerationForMatchAndUpdate(Guid matchId, GeneratorType option)
        {
            _logger.LogInformation($"GenerationService: {HelperMethods.GetCallerMemberName()}");

            bool result = false;
            var match = await _mediator.Send(new GetMatchQuery() { MatchId = matchId });

            if(match == null || match.Status != MatchStatus.Created){return result;}
                //TODO: add error here!

            var generator = SelectGeneratorByGeneratorType(option);
            var generatedMatch = await generator.Generate(match);

            result =  await _mediator.Send(new UpdateMatchTeamsCommand() { Match = generatedMatch });
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ITeamGenerator SelectGeneratorByGeneratorType(GeneratorType type)
        {
            ITeamGenerator generator = new TeamGenerator();

            switch(type)
            {
                case GeneratorType.Random:
                    generator = new TeamGenerator();
                    break;
                case GeneratorType.Manual:
                case GeneratorType.None:
                    break;
            }
            return generator;
        }
    }
}