using CleanArchitecture.API.Swagger;
using CleanArchitecture.Contracts;
using CleanArchitecture.Service.UserRequestHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        [SuccessValidatedResponse(typeof(UserOverview))]
        [FailedValidatedResponse]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
        {
            var request = new GetUserByIdRequest() { Id = id };

            var response = await _mediator.Send(request, cancellationToken);

            return response.ToActionResult(_ => _.User);
        }
    }
}
