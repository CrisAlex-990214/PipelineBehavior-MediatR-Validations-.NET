using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PipelineBehavior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<Result<Guid>> Create(CreateUser user) => await mediator.Send(user);
    }
}
