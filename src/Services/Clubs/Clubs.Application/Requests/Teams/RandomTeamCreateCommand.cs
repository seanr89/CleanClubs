using System;
using System.Threading;
using System.Threading.Tasks;
using Clubs.Application.Services;
using MediatR;

namespace Clubs.Application.Requests.Club.Commands
{
    //Following this concept: https://github.com/jasontaylordev/CleanArchitecture/blob/a731538e35d5ff21cd2ba937bef60a41993970dd/src/Application/TodoLists/Queries/GetTodos/GetTodosQuery.cs

    public class RandomTeamCreateCommand : IRequest<bool>
    {
        public Guid MatchId { get; set; }
    }

    public class RandomTeamCreateCommandHandler : IRequestHandler<RandomTeamCreateCommand, bool>
    {
        private readonly GenerationService _GenerationService;
        public RandomTeamCreateCommandHandler(GenerationService genService)
        {
            _GenerationService = genService;
        }

        public async Task<bool> Handle(RandomTeamCreateCommand request, CancellationToken cancellationToken)
        {
            return await _GenerationService.ExecuteTeamGenerationForMatchAndUpdate(request.MatchId
                                                            , Domain.Enums.GeneratorType.Random);
        }
    }
}



