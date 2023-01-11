using backend.Domain.Dto;
using backend.Domain.Model;
using backend.Service.Interfaces;
using backend.Service.Interfaces.Repository.Read;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace backend.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthReadRepository _authReadRepository;
        private readonly IConfiguration _config;

        public AuthService(IAuthReadRepository authReadRepository, IConfiguration config) {
            _authReadRepository = authReadRepository;
            _config = config;
        }

        public async Task<EntityDto?> AuthenticateUser(string login, string password) {
            User user = await _authReadRepository.ReadUserByCredentials(login, password);
            return user == null ? null : new UserDto() {
                Id = user.Id,
                Fullname = String.Join(" ", user.Name, user.Surname),
                RegisteredOn = user.RegisteredOn
            };
        }

        public string GenerateJSONWebToken<T>(EntityDto entity) where T : EntityDto {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims: new Claim[] { new Claim("entityData", JsonSerializer.Serialize<T>(entity as T)) },
                expires: DateTime.MaxValue,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public T? ReadJwtTokenEntityData<T>(string jwt) where T : EntityDto { 
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var token = handler.ReadToken(jwt) as JwtSecurityToken;
            return JsonSerializer.Deserialize<T>(
                token!.Claims!.First(claim => claim.Type == "entityData").Value
            );
        }
    }
}
