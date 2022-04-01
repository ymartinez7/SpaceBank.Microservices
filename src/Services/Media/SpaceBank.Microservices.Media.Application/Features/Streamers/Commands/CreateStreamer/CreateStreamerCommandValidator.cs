using FluentValidation;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{nombre} no puede exceder los 50 cRcteres");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("La {Url} no puedes estar en blanco");
        }
    }
}
