using FluentValidation;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandValidator : AbstractValidator<DeleteStreamerCommand>
    {
        public DeleteStreamerCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
