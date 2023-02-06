using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Behaviour
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            List<ValidationFailure?> errorsDictionary = new();

            foreach (var val in _validators)
            {
                var validationResult = await val.ValidateAsync(context, cancellationToken);

                var list = validationResult.Errors.Where(x => x != null)
                    .GroupBy(x => new { x.PropertyName, x.ErrorMessage })
                    .Select(x => x.FirstOrDefault())
                    .ToList();

                errorsDictionary.AddRange(list);
            }

            if (errorsDictionary.Any())
            {
                throw new ValidationException(errorsDictionary);
            }

            return await next();
        }
    }
}