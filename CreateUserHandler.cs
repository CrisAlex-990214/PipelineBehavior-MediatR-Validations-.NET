using MediatR;

namespace PipelineBehavior
{
    public class CreateUser : IRequest<Result<Guid>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class CreateUserHandler : IRequestHandler<CreateUser, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
            return new() { Value = Guid.NewGuid() };
        }
    }
}
