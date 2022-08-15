using FluentValidation;
using MediatR;

namespace MeetUp.Logic.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators) => this.validators = validators;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validators.Select(it => it.Validate(context)).SelectMany(res => res.Errors).Where(fail => fail != null).ToList();

            if (failures.Count > 0)
                throw new ValidationException(failures);

            return next();
        }
    }
}
