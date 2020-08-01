using FluentValidation; 

using Clubs.Application.Requests.Club.Commands;

namespace Clubs.Application.Validators
{
    public class CreateClubCommandValidator : AbstractValidator<CreateClubCommand>
    {
        public CreateClubCommandValidator()
        {
            RuleFor(x => x.Club.Name)
                .NotEmpty();

            RuleFor(x => x.Club.Creator)
                .NotEmpty();
        }
    }
}