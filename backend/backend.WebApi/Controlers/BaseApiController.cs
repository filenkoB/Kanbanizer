using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : Controller
    {
        public IMediator Mediator { get; private set; }

        public BaseApiController(IMediator mediator) {
            Mediator = mediator;
        }

        protected virtual async Task<TResult> CallRequestHandler<TResult>(Type requestType, params object[] parameters) {
            var request = Activator.CreateInstance(requestType, parameters) as IRequest<TResult>;
            return await Mediator.Send(request);
        }
    }
}
