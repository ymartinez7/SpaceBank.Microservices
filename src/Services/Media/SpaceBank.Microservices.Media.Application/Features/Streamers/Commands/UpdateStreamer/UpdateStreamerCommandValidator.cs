using FluentValidation;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{name} no puede ser nulo")
                .NotNull();

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{name} no puede ser nulo")
                .NotNull();
        }
    }
}
