using FluentValidation.Results;

namespace SpaceBank.Microservices.Media.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; private set; }

        public ValidationException() : base("Se presentaron uno o más errores de validación")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failutes) : this()
        {
            Errors = failutes.GroupBy(a => a.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGropup => failureGropup.Key, failureGropup => failureGropup
                .ToArray());
        }
    }
}
