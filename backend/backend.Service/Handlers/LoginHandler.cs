using backend.Domain.Dto;
using backend.Service.Interfaces;
using MediatR;

namespace backend.Service.Handlers
{
    public class LoginRequest : IRequest<string>
    {
        public string Login;
        public string Password;

        public LoginRequest(string login, string password) {
            Login = login;
            Password = password;
        }
    }

    public class LoginRequestHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly IAuthService _authService;

        public LoginRequestHandler(IAuthService authService) {
            _authService = authService;
        }

        public async Task<string> Handle(LoginRequest request, CancellationToken _) {
            string login = request.Login;
            string password = request.Password;

            EntityDto? user = await _authService.AuthenticateUser(login, password);
            return user == null
                ? String.Empty
                : _authService.GenerateJSONWebToken<UserDto>(user);
        }
    }
}
