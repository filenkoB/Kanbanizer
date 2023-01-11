using backend.Domain.Dto;
using backend.Service.Extensions;
using backend.Service.Handlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controlers
{
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        public AuthController(IMediator mediator) : base(mediator) {}

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] CredentialDto dto) {
            string jwt = await CallRequestHandler<string>(typeof(LoginRequest), dto.Login, dto.PasswordHash);
            return String.IsNullOrEmpty(jwt) ? Unauthorized() : Ok(new {
                Token = jwt
            });;
        }
    }
}
