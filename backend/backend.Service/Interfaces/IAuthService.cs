using backend.Domain.Dto;

namespace backend.Service.Interfaces
{
    public interface IAuthService
    {
        public string GenerateJSONWebToken<T>(EntityDto entity) where T : EntityDto;
        public Task<EntityDto?> AuthenticateUser(string login, string password);
        public T? ReadJwtTokenEntityData<T>(string jwt) where T : EntityDto;
    }
}
