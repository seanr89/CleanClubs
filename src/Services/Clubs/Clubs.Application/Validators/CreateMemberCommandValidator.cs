using FluentValidation; 

using Clubs.Application.Requests.Club.Commands;
using Clubs.Application.Requests.Member.Commands;

namespace Clubs.Application.Validators
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(x => x.Member.Email)
                .NotEmpty();

            RuleFor(x => x.Member.ClubId)
                .NotEmpty();
        }
    }
}