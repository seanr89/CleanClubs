using FluentValidation; 

using Clubs.Application.Requests.Club.Commands;

namespace Clubs.Application.Validators
{
    public class CreateClubCommandValidator : AbstractValidator<CreateClubCommand>
    {}
}