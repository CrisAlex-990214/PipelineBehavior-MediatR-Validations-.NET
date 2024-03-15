using FluentValidation;
using MediatR;

namespace PipelineBehavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : IResult, new()
    {
        private readonly IValidator<TRequest> validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            this.validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = await validator.ValidateAsync(request);

            return result.IsValid ? await next() :
                new() { IsSuccess = false, Messages = result.Errors.Select(x => x.ErrorMessage) };
        }
    }
}
